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
		//一時保存
		//private static int _tmpEqBait = 0;//餌
		//private static int _tmpStats = 0; //スタミナ

		//private static Thing Bait => EClass.player.eqBait;
		//private static Stats Stats => EClass.player.chara.stamina;
		private static ModConfig.FishingCostEnum FishingCost => (ModConfig.FishingCostEnum)ModConfig.FishingCost.Value;

		private static BaitAndStaminaAllDatas _datasHistory = new BaitAndStaminaAllDatas(); //変化履歴データ

		/// <summary>
		/// 餌とスタミナの変化を保持
		/// </summary>
		public class BaitAndStaminaAllDatas
		{
			public Boolean IsPC;
			public BaitAndStamina Start;
			public BaitAndStamina SystemChange;//システムで変更された値
			public BaitAndStamina Diff;
			public BaitAndStamina Result;

			//[Conditional("DEBUG")]
			public void DispLog() {
				try {
					CommonUtil.OutputLogDoubleLines();
					Start.LogDisp("start: ");
					SystemChange.LogDisp("systemChange: ");
					Diff.LogDisp("diff: ");
					Result.LogDisp("result: ");
					CommonUtil.OutputLogDoubleLines();


				} catch (Exception) {
				}
			}

			//[Conditional("DEBUG")]
			public void DispExitParams(AI_Fish.ProgressFish instance, Chara owner) {
				CommonUtil.OutputLogDoubleLines();
				CommonUtil.OutputSimpleLog(IsPC ? "PC" : "Other");
				CommonUtil.OutputLogDoubleLines();
				CommonUtil.OutputSimpleLog("AI_Fish:");
				CommonUtil.OutputSimpleLog("餌:設定なし");
				CommonUtil.OutputSimpleLog("スタミナ:" + instance.owner.stamina);

				CommonUtil.OutputSimpleLog("owner:");
				CommonUtil.OutputSimpleLog("餌:設定なし");
				CommonUtil.OutputSimpleLog("スタミナ:" + owner.stamina);

				CommonUtil.OutputSimpleLog("EClass.player:");
				CommonUtil.OutputSimpleLog("餌:" + EClass.player.eqBait.Num);
				CommonUtil.OutputSimpleLog("スタミナ:なし");
				CommonUtil.OutputLogDoubleLines();
			}
		}

		public class BaitAndStamina
		{
			public BaitAndStamina(int bait, int stamina) {
				Bait = bait;
				Stamina = stamina;
			}
			public BaitAndStamina(Chara owner) {
				IsPC = owner.IsPC;

				Name = owner.Name;
				Bait = IsPC ? EClass.player.eqBait.Num : 0;
				Stamina = IsPC ? EClass.player.chara.stamina.GetValue() : owner.stamina.GetValue();
			}
			public int Bait;
			public int Stamina;
			public bool IsPC;
			public String Name;

			[Conditional("DEBUG")]
			public void LogDisp(string mess) {
				try {
					string message = "Nem:" + Name + ", 餌：" + Bait.ToString() + ", スタミナ" + Stamina.ToString();
					CommonUtil.OutputSimpleLog(mess + message);
				} catch (Exception) {
				}
			}
		}

		//先行処理
		public static void Prefix(AI_Fish.ProgressFish __instance) {
			CommonUtil.OutputShowNameLog("test:start");
			_datasHistory.Start = new BaitAndStamina(__instance.owner);
			_datasHistory.Start.LogDisp("");
			CommonUtil.OutputShowNameLog("test:end");

			if (FishingCost == ModConfig.FishingCostEnum.DefVal) return;


			//CommonUtil.OutputShowNameLog("start");
			////値を保存
			//_tmpEqBait = Bait.Num;
			//_tmpStats = Stats.GetValue();
			//CommonUtil.OutputShowNameLog("処理前");
			//CommonUtil.OutputShowNameLog("餌：" + _tmpEqBait.ToString());
			//CommonUtil.OutputShowNameLog("スタミナ：" + _tmpStats.ToString());
		}

		//後続処理
		public static void Postfix() {
			if (FishingCost == ModConfig.FishingCostEnum.DefVal) return;

			//   CommonUtil.OutputShowNameLog("start");
			//   //スタミナの差分
			//   int a = Math.Abs(_tmpStats);
			//   int b = Math.Abs(Stats.GetValue());
			//   int diff = (a > b) ? a - b : b - a;
			//   CommonUtil.OutputShowNameLog("処理後");
			//   CommonUtil.OutputShowNameLog("スタミナ（処理後）：" + b.ToString());
			//   CommonUtil.OutputShowNameLog("スタミナ（差分）：" + diff.ToString());
			//   CommonUtil.OutputShowNameLog("--");


			//   //スタミナの消費を1とする
			//   if ((_tmpStats - 1) != Stats.GetValue()) {
			//    Stats.Set(_tmpStats);
			//    Stats.Mod(-1);
			//   }


			//   if (FishingCost != ModConfig.FishingCostEnum.AllOne) {
			//    //餌の消費を増やす（常に -1 されるので +1 する）
			//    if (diff != 0) {
			//	    int baitCost = -1 * diff + 1;
			//	    Bait.ModNum(baitCost);
			//    }
			//   }

			//CommonUtil.OutputShowNameLog("処理後（最終値）");
			//   CommonUtil.OutputShowNameLog("餌：" + Bait.Num.ToString());
			//   CommonUtil.OutputShowNameLog("スタミナ：" + Stats.GetValue().ToString());
		}
	}
}
