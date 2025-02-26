using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace RmModManager.Util
{
    public static class CommonUtil
    {
		[Conditional("DEBUG")]
		public static void OutputLog(string text, [CallerMemberName] string callerMethodName = "") {
		    try {
			    string s = "RmMod:" + ModInfo.Name + ":" + callerMethodName + ":" + text;
			    UnityEngine.Debug.Log(s);
			    Msg.SayGod(s);
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
