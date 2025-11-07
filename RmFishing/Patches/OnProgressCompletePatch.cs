using HarmonyLib;

using RmModManager.UI.ModOptions;
using RmModManager.Util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

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
			public BaitAndStamina Start;
			public BaitAndStamina SystemChange;//システムで変更された値
			public BaitAndStamina Diff;
			public BaitAndStamina Result;

			//[Conditional("DEBUG")]
			public void DispLog() {
				try {
					CommonUtil.OutputLogLinesDouble();

					Start.LogShow("start: ");
					SystemChange.LogShow("systemChange: ");
					Diff.LogShow("diff: ");
					Result.LogShow("result: ");
					CommonUtil.OutputLogLinesDouble();


				} catch (Exception) {
				}
			}

			[Conditional("DEBUG")]
			public void DispExitParams() {
				CommonUtil.OutputLogLinesDouble();
				CommonUtil.OutputSimpleLog("システム判断：" + (IsPC ? "プレイヤー" : "Other"));
				CommonUtil.OutputLogLinesSingle();
				CommonUtil.OutputSimpleLog("AI_Fish:");
				Start.ShowData("");
				CommonUtil.OutputLogLinesSingle();
				CommonUtil.OutputSimpleLog("owner:");
				Start.ShowData("");
				CommonUtil.OutputLogLinesSingle();
				CommonUtil.OutputSimpleLog("EClass.player:");
				Start.ShowData("");
				CommonUtil.OutputLogLinesDouble();
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
				try {
					string message = "対象：" + _name + "餌：" + Bait.ToString() + ", スタミナ" + Stamina.ToString();
					CommonUtil.OutputSimpleLog(mess + message);
				} catch (Exception) {
				}
			}
			[Conditional("DEBUG")]
			public void ShowData(string mess) {
				try {
					string message = "餌：" + Bait.ToString() + ", スタミナ" + Stamina.ToString();
					CommonUtil.OutputSimpleLog(mess + ", " + message);
				} catch (Exception) {
				}
			}
		}

		//先行処理
		public static void Prefix(AI_Fish.ProgressFish __instance) {
			_datasHistory.Start = new BaitAndStamina(__instance.owner);

			if (FishingCost == ModConfig.FishingCostEnum.DefVal) return;
		}

		//後続処理
		public static void Postfix(AI_Fish.ProgressFish __instance) {
			_datasHistory.SystemChange = new BaitAndStamina(__instance.owner);
			_datasHistory.SystemChange.LogShow("処理後：");

			if (FishingCost == ModConfig.FishingCostEnum.DefVal) return;

			var chara = __instance.owner;
			//スタミナの消費を1とする
			chara.stamina.Set(_datasHistory.Start.Stamina);
			chara.stamina.Mod(-1);


			if (FishingCost != ModConfig.FishingCostEnum.AllOne) {
				//餌の消費を1にする
				if (chara.IsPC) {

					EClass.player.eqBait.ModNum(_datasHistory.Start.Bait - 1);
				}
			}
			_datasHistory.SystemChange = new BaitAndStamina(__instance.owner);
			_datasHistory.SystemChange.LogShow("修正後：");


			_datasHistory.DispExitParams();
		}
	}
}
