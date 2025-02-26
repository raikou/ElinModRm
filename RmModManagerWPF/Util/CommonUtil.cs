using RmModManagerWPF.Util;

using RTools;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

using Path = System.IO.Path;

namespace RmModManager.Util
{
    public static class CommonUtil
    {
	    public static Settings Settings;

	    private static readonly string DesktopPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
	    private const string FileName = "RmModManager.log";
	    private static XmlUsing xmlUsing = new XmlUsing();
	    private static string dirPath = Directory.GetCurrentDirectory();
	    private static string fileName = "rm_mod_manager_settings.xml";

		private static StreamWriter _sw = new StreamWriter( Path.Combine(DesktopPath, FileName));

		[Conditional("DEBUG")]
		public static void OutputLog(string text, [CallerMemberName] string callerMethodName = "") {
		    try {
			    string s = callerMethodName + ":" + text;
				_sw.WriteLine(s);
		    } catch (Exception e) {
		    }
	    }

	    [Conditional("DEBUG")]
	    public static void OutputLog(Exception e, [CallerMemberName] string callerMethodName = "") {
		    try {
				OutputLog("Error:" + e.Message + "\\\n" + e.StackTrace, callerMethodName);
		    } catch (Exception exception) {
			    
		    }
	    }

	    public static void Save(Settings settings) {
		    xmlUsing.Save(settings, Path.Combine(dirPath, fileName));
	    }

	    public static void Load() {
		    var path = Path.Combine(dirPath, fileName);
		    if (File.Exists(path)) {
			    xmlUsing.Load(out Settings, path);
		    } else {
				Save(new Settings());
		    }
		}

	}
}
