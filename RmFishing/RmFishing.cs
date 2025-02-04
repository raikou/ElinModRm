/* 参考：
 * https://docs.google.com/document/d/e/2PACX-1vSu2UfqCJl5095uOlem2Y3al20JotndDJcB3wjh82O2nQJ4yx8fC__IfUF6M_QRoWbb0Di9mdDnM3_Q/pub
 * https://elin-modding-resources.github.io/Elin.Docs/
 * */


using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace RmFishing
{
	internal static class ModInfo
	{
		public const string Major = "0";
		public const string Minor = "1";
		public const string Patch = "0";
		public const string Build = "0";

		public const string Name = "RmFishing";
		public const string Guid = "net.raireitei" + Name;
		public const string Version = Major + "." + Minor + "." + Patch + "." + Build;
	}

	//Mdo のヘッダー
	[BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
	public class RmFishing_Header : BaseUnityPlugin
	{
		private void Start() {
			UnityEngine.Debug.Log(ModInfo.Name + " Start");
			new Harmony(ModInfo.Name).PatchAll();
		}
	}

	//Mod の基本処理
	[HarmonyPatch(typeof(AI_Fish.ProgressFish), nameof(AI_Fish.OnProgressComplete))]
	public class RmFishing
	{
		//一時保存
		static private int tmpEqBait = 0;//餌
		static private int tmpStats = 0; //スタミナ

		static private Thing bait => EClass.player.eqBait;
		static private Stats stats => EClass.player.chara.stamina;

		//先行処理
		public static void Prefix() {
			OutputLog("start");
			//値を保存
			tmpEqBait = bait.Num;
			tmpStats = stats.GetValue();
			OutputLog("処理前");
			OutputLog("餌：" + tmpEqBait.ToString());
			OutputLog("スタミナ：" + tmpStats.ToString());
		}

		//後続処理
		public static void Postfix() {
			OutputLog(text: "start");
			//スタミナの差分
			int a = Math.Abs(tmpStats);
			int b = Math.Abs(stats.GetValue());
			int diff =  (a > b)?  a - b : b - a;
			OutputLog("処理後");
			OutputLog("スタミナ（処理後）：" + b.ToString());
			OutputLog("スタミナ（差分）：" + diff.ToString());
			OutputLog("--");


			//スタミナの消費を1とする
			if ((tmpStats - 1) != stats.GetValue()) {
				stats.Set(tmpStats);
				stats.Mod(-1);
			}

			//餌の消費を増やす（常に -1 されるので +1 する）
			if (diff != 0) {
				int baitCost = -1 * diff + 1;
				bait.ModNum(baitCost);
			}

			OutputLog("処理後（最終値）");
			OutputLog("餌：" + bait.Num.ToString());
			OutputLog("スタミナ：" + stats.GetValue().ToString());

		}

		[Conditional("DEBUG")]
		private static void OutputLog(string text, [CallerMemberName] string callerMethodName = "") {
			string s = ModInfo.Name + ":" + callerMethodName + ":" + text;
			UnityEngine.Debug.Log(s);
			Msg.SayGod(s);
		}
	}
}
