using System;

using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace RnFishing
{
	//Mdo のヘッダー、mバージョン情報
	[BepInPlugin("net.raireitei.rnfishing", "RnFishing", "1.0.0.0")]
	public class RnFishing_Header : BaseUnityPlugin
	{
		private void Start() {
			string name = GetType().Name;
			Debug.Log(name + " Start");
			new Harmony(name).PatchAll();
		}
	}

	//Mod の基本処理
	[HarmonyPatch]
	public class RnFishing
	{
		private int tmpEqBait = 0;
		private int tmpStamina = 0;

		//先行処理
		[HarmonyPatch(typeof(AI_Fish), nameof(AI_Fish.OnProgressComplete))]
		public void Prefix() {
			tmpEqBait = EClass.player.eqBait.Num;
			tmpStamina 
		}

		//後続処理


	}




	//以下、参考メモ（他のMOD制作者様）
	/*
	[HarmonyPatch]
	public class RnFishing
    {
		[HarmonyPrefix, HarmonyPatch(typeof(Map), nameof(Map.TrySmoothPick), new Type[] { typeof(Cell), typeof(Thing), typeof(Chara) })]
		public static void TrySmoothPick(GrowSystem __instance, Cell cell, Thing t, Chara c) {
			if (t?.category?.id=="seed" && t.Num < 5) {
				t.SetNum(5);
				c?.ModExp(286, 20);
			}
			return ;
		}
		[HarmonyPostfix, HarmonyPatch(typeof(GrowSystem), nameof(GrowSystem.TryPopSeed))]
		public static void TryPopSeed(GrowSystem __instance, Thing __result, Chara c) {
			if (__result == null && __instance.source.HasTag(CTAG.seed) && !EClass.player.isAutoFarming) {
				__result = TraitSeed.MakeSeed(__instance.source, EClass._map.TryGetPlant(GrowSystem.cell));
				if (__result?.Num < 5) {
					__result.SetNum(5);
				}
				__instance.TryPick(GrowSystem.cell, __result, c);
				c?.ModExp(286, 20);
			}
			if (__result?.Num < 5) {
				__result.SetNum(5);
			}
			return;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(TraitSeed), nameof(TraitSeed.MakeSeed), new Type[] { typeof(SourceObj.Row), typeof(PlantData) })]
		public static void MakeSeed(TraitSeed __instance, SourceObj.Row obj, PlantData plant = null) {
			if(plant != null) {
				plant.water = 10000;
			}
			return;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(TraitSeed), nameof(TraitSeed.LevelSeed))]
		public static bool LevelSeed(TraitSeed __instance, Thing t, SourceObj.Row obj, int num) {
			string trace = Environment.StackTrace;
			if (trace.IndexOf("MakeSeed") < 0) {
				return true;
			}
			num = EClass.pc.Evalue(286) - t.encLV;
			for (int index = 0; index < num; ++index) {
				if (obj == null || obj.objType == "crop") {
					if (t.encLV == 0) {
						CraftUtil.AddRandomFoodEnc(t);
					} else {
						Rand.SetSeed(t.c_seed);
						CraftUtil.ModRandomFoodEnc(t);
					}
				}

				t.ModEncLv(1);
			}
			return false;
		}
		[HarmonyPrefix, HarmonyPatch(typeof(TraitToolWaterCan), nameof(TraitToolWaterCan.MaxCharge), MethodType.Getter)]
		public static bool MaxAlly(TraitToolWaterCan __instance, ref int __result) {
			__result = __instance.owner.material.hardness*5+4;
			return false;
		}
	}
	*/
}
