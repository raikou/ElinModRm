using HarmonyLib;

using JetBrains.Annotations;

using RmModManager.UI.ModOptions;
using RmModManager.Util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

using UnityEngine;

namespace RmModManager.Patches
{
	[HarmonyPatch(typeof(AI_Fish.ProgressFish), nameof(AI_Fish.OnProgressComplete))]
	public class OnProgressCompletePatch
	{
		private static ModConfig.FishingCostEnum FishingCost => (ModConfig.FishingCostEnum)ModConfig.FishingCost.Value;
		private static BaitAndStaminaAllDatas _datasHistory = new BaitAndStaminaAllDatas(); //変化履歴データ

		/// <summary>
		/// 餌とスタミナの変化を保持
		/// </summary>
		private class BaitAndStaminaAllDatas
		{
			public Boolean IsPC;
			public BaitAndStamina Start ;
			public BaitAndStamina SystemChange = null;//システムで変更された値
			public BaitAndStamina Diff = null;
			public BaitAndStamina Result = null;

			[Conditional("DEBUG")]
			public void DispLog() {
				try {
					CommonUtil.OutputLogLinesDouble();
					Show(Start,"start:");
					Show(SystemChange,"systemChange:");
					Show(Diff,"diff:");
					Show(Result,"result:");
					CommonUtil.OutputLogLinesDouble();
				} catch (Exception e) {
					CommonUtil.OutputErrorLog(e);
				}
			}

			public void Show([CanBeNull] BaitAndStamina data, String mess) {
				if (data == null) {
					CommonUtil.OutputSimpleLog(":nothing");
				} else {
					data.LogShow(mess);
				}
			}
		}

		public class BaitAndStamina
		{
			public readonly int Bait;
			public readonly int Stamina;
			private readonly bool _isPC;
			private readonly String _name;

			public BaitAndStamina(Chara owner) {
				_isPC = owner.IsPC;

				_name = owner.Name;
				Bait = _isPC ? EClass.player.eqBait.Num : 0;
				Stamina = _isPC ? EClass.player.chara.stamina.GetValue() : owner.stamina.GetValue();
			}

			[Conditional("DEBUG")]
			public void LogShow(string mess) {
				ShowData(mess);
			}
			[Conditional("DEBUG")]
			protected void ShowData(string mess) {
				try {
					string message = "対象：" + _name + "餌：" + Bait.ToString() + ", スタミナ" + Stamina.ToString();
					CommonUtil.OutputSimpleLog(mess + ", " + message);
				} catch (Exception) {
					CommonUtil.OutputSimpleLog(mess + ", err");
				}
			}
		}

		//先行処理
		public static void Prefix(AI_Fish.ProgressFish __instance) {
			try {
				_datasHistory.Start = new BaitAndStamina(__instance.owner);

				if (FishingCost == ModConfig.FishingCostEnum.DefVal) return;
			} catch (Exception e) {
				CommonUtil.OutputErrorLog(e);
			}
		}

		//後続処理
		public static void Postfix(AI_Fish.ProgressFish __instance) {
			try {
				_datasHistory.SystemChange = new BaitAndStamina(__instance.owner);
				//_datasHistory.SystemChange.LogShow("処理後：");

				_datasHistory.SystemChange.LogShow("確認：1");

				if (FishingCost == ModConfig.FishingCostEnum.DefVal) return;
				_datasHistory.SystemChange.LogShow("確認：2");

				var chara = __instance.owner;
				//スタミナの消費を1とする
				chara.stamina.Set(_datasHistory.Start.Stamina);
				chara.stamina.Mod(-1);
				_datasHistory.SystemChange.LogShow("確認：3");


				if (FishingCost != ModConfig.FishingCostEnum.AllOne) {
					_datasHistory.SystemChange.LogShow("確認：4");
					//餌の消費を1にする
					if (chara.IsPC) {
						_datasHistory.SystemChange.LogShow("確認：5");

						EClass.player.eqBait.ModNum(_datasHistory.Start.Bait - 1);
						_datasHistory.SystemChange.LogShow("確認：6");
					}
				}
				_datasHistory.SystemChange.LogShow("確認：7");
				_datasHistory.SystemChange = new BaitAndStamina(__instance.owner);
				//_datasHistory.SystemChange.LogShow("修正後：");
				_datasHistory.SystemChange.LogShow("確認：8");

				_datasHistory.DispLog();
				//_datasHistory.DispExitParams();
				_datasHistory.SystemChange.LogShow("確認：9");
			} catch (Exception e) {
				CommonUtil.OutputErrorLog(e);
				_datasHistory.SystemChange.LogShow("確認：error");
				throw;
			}
		}
	}
}
