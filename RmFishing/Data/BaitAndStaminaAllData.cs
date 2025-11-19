using JetBrains.Annotations;

using RmFishing.Util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using static RmFishing.Patches.OnProgressCompletePatch;

namespace RmFishing.Data
{
	/// <summary>
	/// 餌とスタミナの変化を保持
	/// </summary>
	public class BaitAndStaminaAllData
	{
		public readonly List<BaitAndStamina> History = new List<BaitAndStamina>();

		public void Add(string name, Chara owner) {
			History.Add(new BaitAndStamina(name, owner));
		}

		public BaitAndStamina GetFirst() {
			return History[0];
		}

		[Conditional("DEBUG")]
		public void DispLog() {
			try {
				CommonUtil.OutputLogLinesDouble();
				foreach (BaitAndStamina data in History) {
					data.ShowData();
				}
				CommonUtil.OutputLogLinesDouble();
			} catch (Exception e) {
				CommonUtil.OutputErrorLog(e);
			}
		}
	}

}
