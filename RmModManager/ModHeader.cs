/* 参考：
 * https://docs.google.com/document/d/e/2PACX-1vSu2UfqCJl5095uOlem2Y3al20JotndDJcB3wjh82O2nQJ4yx8fC__IfUF6M_QRoWbb0Di9mdDnM3_Q/pub
 * https://elin-modding-resources.github.io/Elin.Docs/
 * */


using BepInEx;
using HarmonyLib;

using RmModManager.Patches;

namespace RmModManager
{
	public static class ModInfo
	{
		private const string Major = "0";
		private const string Minor = "0";
		private const string Patch = "1";
		private const string Build = "0";

		public const string Name = "RmModManager";
		public const string Guid = "net.raireitei." + Name;
		public const string Version = Major + "." + Minor + "." + Patch + "." + Build;
	}

	//Mdo のヘッダー
	[BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
	public class ModHeader : BaseUnityPlugin
	{
		private void Awake() {
			Harmony.CreateAndPatchAll(typeof(OnInitPatch), ModInfo.Guid);
		}

		private void Start() {
		}
	}
}
