using HarmonyLib;

using RmFishing.Data;
using RmFishing.Util;

using System;

namespace RmFishing.Patches
{
	[HarmonyPatch(typeof(AI_Fish.ProgressFish), nameof(AI_Fish.OnProgressComplete))]
	public class OnProgressCompletePatch
	{
		private static ModConfig.FishingCostEnum FishingCost => (ModConfig.FishingCostEnum)ModConfig.FishingCost.Value;
		private static BaitAndStaminaAllData _dataHistory; //変化履歴データ

		//先行処理
		public static void Prefix(AI_Fish.ProgressFish __instance) {
			try {
				CommonUtil.OutputSimpleLog("確認：0 : Prefix start ");
				_dataHistory = new BaitAndStaminaAllData();
				_dataHistory.Add("Start" ,__instance.owner);

			} catch (Exception e) {
				CommonUtil.OutputSimpleLog("確認：0 : Prefix: error");
			}
		}

		//後続処理
		public static void Postfix(AI_Fish.ProgressFish __instance) {
			try {
				if (FishingCost == ModConfig.FishingCostEnum.DefaultCost ||
				    FishingCost == ModConfig.FishingCostEnum.ChangeCost) {
					CommonUtil.OutputSimpleLog("確認：0 : Postfix start: デフォルトの為終了 ");
					return;
				}
				CommonUtil.OutputSimpleLog("確認：0 : Postfix start ");

				_dataHistory.Add("SystemChange",__instance.owner);


				var chara = __instance.owner;

				if (FishingCost == ModConfig.FishingCostEnum.BothOne ||
				    FishingCost == ModConfig.FishingCostEnum.StaminaIsOne) {
					//スタミナの消費を1とする
					chara.stamina.Set(_dataHistory.GetFirst().Stamina);
					chara.stamina.Mod(-1);
					CommonUtil.OutputSimpleLog("確認：スタミナ消費を1に変更 ");
				}

				if (FishingCost == ModConfig.FishingCostEnum.BothOne ||
				    FishingCost == ModConfig.FishingCostEnum.BaitIsOne) {
					//餌の消費を1にする
					if (chara.IsPC) {
						CommonUtil.OutputSimpleLog("確認：is PC");
						EClass.player.eqBait.SetNum(_dataHistory.GetFirst().Bait);
						EClass.player.eqBait.ModNum(- 1);
						CommonUtil.OutputSimpleLog("確認：餌の消費を1に変更 ");
					} else {
						CommonUtil.OutputSimpleLog("確認：餌の消費を1に変更 ※NPCの為関係なし ");
					}
				}

				_dataHistory.Add("最終値", __instance.owner);

				_dataHistory.DispLog();
				CommonUtil.OutputSimpleLog("確認：Postfix end ");
			} catch (Exception e) {
				CommonUtil.OutputSimpleLog("確認：Postfix : error");
			}
		}
	}
}
