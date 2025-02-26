using RTools;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Path = System.IO.Path;


namespace RmModManagerWPF.Util
{
	public class Settings
	{
		private bool _isLoad = false;
		public int SplitterX = -1;

		private static readonly XmlUsing XmlUsing = new XmlUsing();
		private static readonly string DirPath = Directory.GetCurrentDirectory();
		private static readonly string FileName = "rm_mod_manager_settings.xml";

		private static string path => Path.Combine(DirPath, FileName);

		public void Save(Settings? settings) {
			if (settings?._isLoad == false) {
				settings = new Settings() {
					_isLoad = true,
					SplitterX = 260
				};
			}
			XmlUsing.Save(settings, path);
		}

		public Settings Load() {
			if (File.Exists(path) == false) {
				Save(new Settings());
			}

			XmlUsing.Load(out Settings result, path);
			result._isLoad = true;

			return result;

		}

	}
}
