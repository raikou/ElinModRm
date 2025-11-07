using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace RmModManager.Util
{
    public static class CommonUtil
    {
	    private const string RmMod = "";// "RmMod:";
	    private const string DoubleLine = "===========================================";


		[Conditional("DEBUG")]
		public static void OutputLogDoubleLines() {
		    OutputSimpleLog(DoubleLine);
	    }

		[Conditional("DEBUG")]
	    public static void OutputSimpleLog(string text) {
		    try {
			    UnityEngine.Debug.Log(text);
			    Msg.SayGod(text);
		    } catch (Exception e) {
			}
		}


		[Conditional("DEBUG")]
		public static void OutputShowNameLog(string text, [CallerMemberName] string callerMethodName = "") {
		    try {
			    string s = RmMod + ModInfo.Name + ":" + callerMethodName + ":" + text;
			    UnityEngine.Debug.Log(s);
			    Msg.SayGod(s);
		    } catch (Exception e) {
			}
		}

	    [Conditional("DEBUG")]
	    public static void OutputErrorLog(Exception e, [CallerMemberName] string callerMethodName = "") {
		    try {
				OutputShowNameLog("Error:" + e.Message + "\\\n" + e.StackTrace, callerMethodName);
		    } catch (Exception exceptwion) {
			}
		}
	}
}
