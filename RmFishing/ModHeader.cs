/* 参考：
 * https://docs.google.com/document/d/e/2PACX-1vSu2UfqCJl5095uOlem2Y3al20JotndDJcB3wjh82O2nQJ4yx8fC__IfUF6M_QRoWbb0Di9mdDnM3_Q/pub
 * https://elin-modding-resources.github.io/Elin.Docs/
 * */


using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using BepInEx;
using HarmonyLib;

using RmFishing.UI.ModOptions;

using UnityEngine;

namespace RmFishing
{
	internal static class ModInfo
	{
		private const string Major = "0";
		private const string Minor = "1";
		private const string Patch = "0";
		private const string Build = "1";

		public const string Name = "RmFishing";
		public const string Guid = "net.raireitei" + Name;
		public const string Version = Major + "." + Minor + "." + Patch + "." + Build;
	}

	//Mdo のヘッダー
	[BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
	public class ModHeader : BaseUnityPlugin
	{
		private void Start() {
			UnityEngine.Debug.Log(ModInfo.Name + " Start");
			new Harmony(ModInfo.Name).PatchAll();
		}
	}
}
