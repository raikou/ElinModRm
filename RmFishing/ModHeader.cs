/* 参考：
 * https://docs.google.com/document/d/e/2PACX-1vSu2UfqCJl5095uOlem2Y3al20JotndDJcB3wjh82O2nQJ4yx8fC__IfUF6M_QRoWbb0Di9mdDnM3_Q/pub
 * https://elin-modding-resources.github.io/Elin.Docs/
 * */


using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using BepInEx;
using HarmonyLib;

using RmModManager.Patches;
using RmModManager.UI.ModOptions;
using RmModManager.Util;

using UnityEngine;

namespace RmModManager
{
	public static class ModInfo
	{
		private const string Major = "0";
		private const string Minor = "1";
		private const string Patch = "1";
		private const string Build = "0";

		public const string Name = "RmFishing";
		public const string Guid = "net.raireitei." + Name;
		public const string Version = Major + "." + Minor + "." + Patch + "." + Build;
	}

	//Mdo のヘッダー
	[BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
	public class ModHeader : BaseUnityPlugin
	{
		private void Awake() {
			Harmony.CreateAndPatchAll(typeof(OnProgressCompletePatch), ModInfo.Guid);
			ModConfig.LoadConfig(this.Config);
		}

		private void Start() {
			try {
				if (ModOptions.CheckAndRegisterModOptions()) {
					CommonUtil.OutputLog(this.Config.ConfigFilePath);
					ModConfig.LoadConfig(this.Config);

					CommonUtil.OutputLog("Config_cost:" + ModConfig.FishingCost.Value);

					ModOptions.SetLayout();
				}
			} catch (Exception e) {
			}
		}
	}
}
