using BepInEx.Configuration;

namespace RmFishing
{
    internal static class ModConfig
    {
		public enum FishingCostEnum{
			DefaultCost = 0,
			ChangeCost = 1,
			BothOne = 2,
			StaminaIsOne = 3,
			BaitIsOne = 4
		}

		/// <summary>
		/// 0:デフォルトコスト
		/// 1:スタミナ値と釣り餌の入れ替え
		/// 2:消費コストを両方「1」にする
		/// </summary>
		internal static ConfigEntry<int> FishingCost;

		internal static void LoadConfig(ConfigFile config) {
			FishingCost = config.Bind<int>(ModInfo.Guid
				, nameof(FishingCost), FishingCostEnum.ChangeCost.GetHashCode(), "");
		}
    }
}
