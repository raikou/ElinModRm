/* 参考：
 * https://docs.google.com/document/d/e/2PACX-1vSu2UfqCJl5095uOlem2Y3al20JotndDJcB3wjh82O2nQJ4yx8fC__IfUF6M_QRoWbb0Di9mdDnM3_Q/pub
 * https://www.umayadia.com/cssample/sample0000/dnSampleGetPrevMethodName.htm
 * */


using System;
using System.Runtime.CompilerServices;

using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace RnFishing
{
	static class Const
	{
		public const string className = "RnFishing";
	}


	//Mdo のヘッダー、mバージョン情報
	[BepInPlugin("net.raireitei.rnfishing", Const.className, "1.0.0.0")]
	public class RnFishing_Header : BaseUnityPlugin
	{
		private void Start() {
			string className = Const.className;
			Debug.Log(className + " Start");
			new Harmony(className).PatchAll();
		}
	}

	//Mod の基本処理
	[HarmonyPatch(typeof(AI_Fish), nameof(AI_Fish.OnProgressComplete))]
	public class RnFishing
	{
		
		//一時保存
		static private int tmpEqBait = 0;//餌
		static private int tmpStats = 0;//スタミナ

		static private Thing bait => EClass.player.eqBait;
		static private Stats stats => EClass.player.chara.stamina;

		//先行処理
		public static void Prefix() {
			OutputLog(text: "start");
			//値を保存
			tmpEqBait = bait.Num;
			tmpStats = stats.GetValue();
		}

		//後続処理
		public static void Postfix(AI_Fish fish) {
			OutputLog(text: "start");
			//スタミナの差分
			int a = Math.Abs(tmpStats);
			int b = Math.Abs(stats.GetValue());
			int diff =  (a > b)?  a - b : b - a;

			//スタミナの消費を1とする
			if ((tmpStats - 1) != stats.GetValue()) {
				stats.Set(tmpStats);
				stats.Mod(-1);
			}

			//餌の消費を増やす
			bait.ModNum(-1 * diff);

		}

		private static void OutputLog([CallerMemberName] string callerMethodName = "", string text = "") {
			Debug.Log(Const.className + ":" + callerMethodName + ":" + text );
		}
	}
}
