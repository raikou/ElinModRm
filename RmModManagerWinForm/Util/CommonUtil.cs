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
	    private static Settings _settings = new Settings();
	    public static Settings Settings {
		    get => _settings.Load();
		    set => _settings.Save(_settings);
	    }

	    private static readonly string DesktopPath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
	    private const string FileName = "RmModManager.log";

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


	}
}
