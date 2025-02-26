using BepInEx.Configuration;

using System;
using System.Collections.Generic;
using System.Text;

namespace RmFishing
{
    internal static class ModConfig
    {
		public enum FishingCostEnum{
			DefVal = 0,
			ChangeVal = 1,
			AllOne = 2
		}

		/// <summary>
		/// 0:デフォルトコスト
		/// 1:スタミナ値と釣り餌の入れ替え
		/// 2:消費コストを両方「1」にする
		/// </summary>
		internal static ConfigEntry<int> FishingCost;

		internal static void LoadConfig(ConfigFile config) {
			FishingCost = config.Bind<int>(ModInfo.Guid
				, nameof(FishingCost), FishingCostEnum.ChangeVal.GetHashCode(), "");
		}
    }
}
