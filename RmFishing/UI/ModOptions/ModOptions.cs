using BepInEx;

using EvilMask.Elin.ModOptions;
using EvilMask.Elin.ModOptions.UI;

using RmFishing.Util;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using UnityEngine;

namespace RmFishing.UI.ModOptions
{
	public static class ModOptions
	{
		private const string ModOptionsGuid = "evilmask.elinplugins.modoptions";
		private static ModOptionController _modOptionController = null;

		public static void RegisterModOptions() {
			foreach (object obj in ModManager.ListPluginObject) {
				if (!(obj is BaseUnityPlugin baseUnityPlugin) || baseUnityPlugin.Info.Metadata.GUID != ModOptionsGuid) {
					continue;
				}

				if (_modOptionController != null) return;

				_modOptionController = ModOptionController.Register(ModInfo.Guid, "RmFishing", Array.Empty<object>());
			}
		}


		/// <summary>
		/// ModOptionsがMODにあるかチェックする
		/// </summary>
		/// <returns>Modの有無</returns>
		public static bool CheckAndRegisterModOptions() {
			CommonUtil.OutputLog("Start");

			try {
				RegisterModOptions();

				var pluginList = new List<BaseUnityPlugin>();
				foreach (var p in ModManager.ListPluginObject) {
					if (p is BaseUnityPlugin plugin) {
						pluginList.Add(plugin);
					}
				}
				CommonUtil.OutputLog("Start2");

				var modOption = pluginList.FirstOrDefault(obj => obj.Info.Metadata.GUID == ModOptionsGuid);
				if (modOption == null) return false;

				return modOption != null;
			} catch (Exception e) {
				CommonUtil.OutputLog(e);
			}

			CommonUtil.OutputLog("End");
			return false;
		}

		/// <summary>
		/// レイアウトを設定する
		/// </summary>
		public static void SetLayout() {
			try {
				CommonUtil.OutputLog("Start");

				//レイアウトの設定情報読み込み
				LoadLayoutSettings();

				//オプション設定操作結果反映
				_modOptionController.OnBuildUI += (Action<OptionUIBuilder>)(builder => {
					var fishingCostDropDown = builder.GetPreBuild<OptDropdown>("fishingCostDropDown");
					fishingCostDropDown.Value = ModConfig.FishingCost.Value;
					fishingCostDropDown.OnValueChanged += num => {
						ModConfig.FishingCost.Value = num;
					};
				});


			} catch (Exception e) {
				CommonUtil.OutputLog(e);
			}
			CommonUtil.OutputLog("End");

			return;
		}

		private static void LoadLayoutSettings() {
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (directoryName != null) {
				var xml = Path.Combine(directoryName, "layout.xml");
				var translations = Path.Combine(directoryName, "translations.xlsx");
				CommonUtil.OutputLog("xml:" + xml);
				CommonUtil.OutputLog("translations:" + translations);

				if (File.Exists(xml)) {
					using (StreamReader streamReader = new StreamReader(xml)) {
						_modOptionController.SetPreBuildWithXml(streamReader.ReadToEnd());
					}
				}

				if (File.Exists(translations)) {
					_modOptionController.SetTranslationsFromXslx(translations);
				}
			} else {
				CommonUtil.OutputLog("NoDirectory");
			}

		}
	}
}
