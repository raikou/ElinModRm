using BepInEx;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RmFishing.UI.ModOptions
{
	public class ModOptions
	{
		private const string ModOptionsGuid = "evilmask.elinplugins.modoptions";
		private static readonly BaseUnityPlugin _modOptions = null;

		/// <summary>
		/// ModOptionsがMODにあるかチェックする
		/// </summary>
		/// <returns></returns>
		public BaseUnityPlugin GetModOptions() {
			if (_modOptions != null) {
				return _modOptions;
			}

			return ModManager.ListPluginObject.Select(obj =>
				obj as BaseUnityPlugin).FirstOrDefault(plugin => plugin.Info.Metadata.GUID == ModOptionsGuid);
		}
	}
}
