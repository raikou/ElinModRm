using HarmonyLib;

using RmFishing.UI.ModOptions;

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

	    //ModOptions 登録チェック
	    private ModOptions modOptions = null;
	    private void Awake() {
		    modOptions = new ModOptions();
		    if (modOptions != null) {

		    }
	    }

	    //先行処理
	    public static void Prefix() {
		    OutputLog("start");
		    //値を保存
		    _tmpEqBait = Bait.Num;
		    _tmpStats = Stats.GetValue();
		    OutputLog("処理前");
		    OutputLog("餌：" + _tmpEqBait.ToString());
		    OutputLog("スタミナ：" + _tmpStats.ToString());
	    }

	    //後続処理
	    public static void Postfix() {
		    OutputLog("start");
		    //スタミナの差分
		    int a = Math.Abs(_tmpStats);
		    int b = Math.Abs(Stats.GetValue());
		    int diff = (a > b) ? a - b : b - a;
		    OutputLog("処理後");
		    OutputLog("スタミナ（処理後）：" + b.ToString());
		    OutputLog("スタミナ（差分）：" + diff.ToString());
		    OutputLog("--");


		    //スタミナの消費を1とする
		    if ((_tmpStats - 1) != Stats.GetValue()) {
			    Stats.Set(_tmpStats);
			    Stats.Mod(-1);
		    }

		    //餌の消費を増やす（常に -1 されるので +1 する）
		    if (diff != 0) {
			    int baitCost = -1 * diff + 1;
			    Bait.ModNum(baitCost);
		    }

		    OutputLog("処理後（最終値）");
		    OutputLog("餌：" + Bait.Num.ToString());
		    OutputLog("スタミナ：" + Stats.GetValue().ToString());

	    }

	    [Conditional("DEBUG")]
	    private static void OutputLog(string text, [CallerMemberName] string callerMethodName = "") {
		    string s = ModInfo.Name + ":" + callerMethodName + ":" + text;
		    UnityEngine.Debug.Log(s);
		    Msg.SayGod(s);
	    }
    }

}
