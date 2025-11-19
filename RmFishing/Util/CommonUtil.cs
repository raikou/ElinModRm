using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RmFishing.Util
{
	public static class CommonUtil
	{
		private const string RmMod = "";// "RmMod:";
		private const string LineDouble = "===========================================";
		private const string LineSingle = "-------------------------------------------";


		[Conditional("DEBUG")]
		public static void OutputLogLinesDouble() {
			OutputSimpleLog(LineDouble);
		}
		[Conditional("DEBUG")]
		public static void OutputLogLinesSingle() {
			OutputSimpleLog(LineSingle);
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
				string s = "Error:" + callerMethodName + "\\\n" + e.Message + "\\\n" + e.StackTrace + "\\\n";
				UnityEngine.Debug.Log(s);
				Msg.SayGod(s);

			} catch (Exception exceptwion) {
			}
		}
	}
}
