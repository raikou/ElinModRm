using BepInEx.Core.Logging.Interpolation;

using HarmonyLib;

using RmModManager.Util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RmModManager.Patches
{
    [HarmonyPatch(typeof(LayerMod), nameof(LayerMod.OnInit))]
    public class OnInitPatch
	{
		public static LayerMod Instance;
		public static LayerMod ___Instance;
		public UIList list;
		public UIList list2;
		public UIText textRestart;
		public UIButton toggleDisableMods;

		public ModManager manager => ELayer.core.mods;

		static void Postfix() {

			CommonUtil.OutputLog("RmModManager.Postfix");
			
			//	textRestart.SetActive(false);
			//	toggleDisableMods.SetToggle(ELayer.config.other.disableMods, (Action<bool>)(on =>
			//	{
			//		ELayer.config.other.disableMods = on;
			//		ELayer.config.Save();
			//		textRestart.SetActive(true);
			//	}));
			//	LayerMod.Instance = ___Instance;
			//	UIList list = list;
			//	UIList list2 = list2;
			//	UIList.Callback<BaseModPackage, ItemMod> callback1 = new UIList.Callback<BaseModPackage, ItemMod>();
			//	callback1.onClick = (Action<BaseModPackage, ItemMod>)((a, b) => { });
			//	callback1.onInstantiate = (Action<BaseModPackage, ItemMod>)((a, b) =>
			//	{
			//		a.UpdateMeta(true);
			//		b.package = a;
			//		string s = (ELayer.core.mods.packages.IndexOf(a) + 1).ToString() + ". " + (a.isInPackages ? "[Local] " : "") + a.title;
			//		b.buttonActivate.mainText.SetText(s, !a.IsValidVersion() ? FontColor.Bad : (a.activated ? FontColor.ButtonGeneral : FontColor.Passive));
			//		b.buttonActivate.subText.text = a.version;
			//		b.buttonLock.mainText.text = a.author;
			//		b.buttonUp.SetActive(!a.builtin);
			//		b.buttonDown.SetActive(!a.builtin);
			//		b.buttonToggle.SetToggle(a.willActivate);
			//		b.buttonUp.SetOnClick((Action)(() => Move(a, b, -1)));
			//		b.buttonDown.SetOnClick((Action)(() => Move(a, b, 1)));
			//		UIButton bt = b.buttonToggle;
			//		bt.SetOnClick((Action)(() =>
			//		{
			//			a.willActivate = !a.willActivate;
			//			bt.SetToggle(a.willActivate);
			//			ELayer.core.mods.SaveLoadOrder();
			//			textRestart.SetActive(true);
			//		}));
			//		bt.interactable = !a.builtin;
			//		b.buttonActivate.onClick.AddListener((UnityAction)(() =>
			//		{
			//			Refresh();
			//			UIContextMenu contextMenuInteraction = ELayer.ui.CreateContextMenuInteraction();
			//			if (ELayer.debug.enable || !BaseCore.IsOffline && a.isInPackages && !a.builtin && !ELayer.core.version.demo)
			//				contextMenuInteraction.AddButton("mod_publish", (Action)(() => Core.TryWarnUpload((Action)(() => Dialog.YesNo("mod_publish_warn".lang(a.title, a.id, a.author), (Action)(() => ELayer.core.steam.CreateUserContent(a)))))));
			//			if (!a.builtin)
			//				contextMenuInteraction.AddButton(a.willActivate ? "mod_deactivate" : "mod_activate", (Action)(() =>
			//				{
			//					SE.Click();
			//					a.willActivate = !a.willActivate;
			//					ELayer.core.mods.SaveLoadOrder();
			//					list.List(false);
			//					textRestart.SetActive(true);
			//				}));
			//			contextMenuInteraction.AddButton("mod_info", (Action)(() =>
			//			{
			//				SE.Click();
			//				Util.ShowExplorer(a.dirInfo.FullName + "/package.xml");
			//			}));
			//			contextMenuInteraction.Show();
			//		}));
			//		b.buttonLock.onClick.AddListener((UnityAction)(() => Refresh()));
			//	});
			//	callback1.onList = (Action<UIList.SortMode>)(a =>
			//	{
			//		foreach (BaseModPackage package in manager.packages) {
			//			if (package.builtin)
			//				list2.Add((object)package);
			//			else
			//				list.Add((object)package);
			//		}
			//	});
			//	callback1.onRefresh = new Action(Refresh);
			//	UIList.ICallback callback2 = (UIList.ICallback)callback1;
			//	list2.callbacks = (UIList.ICallback)callback1;
			//	UIList.ICallback callback3 = callback2;
			//	list.callbacks = callback3;
			//	list.List(false);
			//	list2.List(false);

			//	void Move(BaseModPackage p, ItemMod b, int a) {
			//		List<BaseModPackage> packages = ELayer.core.mods.packages;
			//		int num = packages.IndexOf(p);
			//		if (num + a < 0 || num + a >= packages.Count || packages[num + a].builtin) {
			//			SE.BeepSmall();
			//		} else {
			//			packages.Move<BaseModPackage>(p, a);
			//			SE.Tab();
			//			textRestart.SetActive(true);
			//			ELayer.core.mods.SaveLoadOrder();
			//			list.List(false);
			//		}
			//	}
		}
	}
}
