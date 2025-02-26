using HarmonyLib;

using RmFishing.UI.ModOptions;
using RmFishing.Util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace RmFishing.Patches
{
    [HarmonyPatch(typeof(AI_Fish.ProgressFish), nameof(AI_Fish.OnProgressComplete))]
    public class OnProgressCompletePatch
	{
	    //一時保存
	    private static int _tmpEqBait = 0;//餌
	    private static int _tmpStats = 0; //スタミナ

	    private static Thing Bait => EClass.player.eqBait;
	    private static Stats Stats => EClass.player.chara.stamina;
	    private static ModConfig.FishingCostEnum FishingCost => (ModConfig.FishingCostEnum)ModConfig.FishingCost.Value;


	    //先行処理
	    public static void Prefix() {
			if(FishingCost == ModConfig.FishingCostEnum.DefVal) return;

		    CommonUtil.OutputLog("start");
		    //値を保存
		    _tmpEqBait = Bait.Num;
		    _tmpStats = Stats.GetValue();
		    CommonUtil.OutputLog("処理前");
		    CommonUtil.OutputLog("餌：" + _tmpEqBait.ToString());
		    CommonUtil.OutputLog("スタミナ：" + _tmpStats.ToString());
	    }

	    //後続処理
	    public static void Postfix() {
		    if (FishingCost == ModConfig.FishingCostEnum.DefVal) return;

		    CommonUtil.OutputLog("start");
		    //スタミナの差分
		    int a = Math.Abs(_tmpStats);
		    int b = Math.Abs(Stats.GetValue());
		    int diff = (a > b) ? a - b : b - a;
		    CommonUtil.OutputLog("処理後");
		    CommonUtil.OutputLog("スタミナ（処理後）：" + b.ToString());
		    CommonUtil.OutputLog("スタミナ（差分）：" + diff.ToString());
		    CommonUtil.OutputLog("--");


		    //スタミナの消費を1とする
		    if ((_tmpStats - 1) != Stats.GetValue()) {
			    Stats.Set(_tmpStats);
			    Stats.Mod(-1);
		    }


		    if (FishingCost != ModConfig.FishingCostEnum.AllOne) {
			    //餌の消費を増やす（常に -1 されるので +1 する）
			    if (diff != 0) {
				    int baitCost = -1 * diff + 1;
				    Bait.ModNum(baitCost);
			    }
		    }

			CommonUtil.OutputLog("処理後（最終値）");
		    CommonUtil.OutputLog("餌：" + Bait.Num.ToString());
		    CommonUtil.OutputLog("スタミナ：" + Stats.GetValue().ToString());

	    }
    }
}
