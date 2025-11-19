using RmFishing.Util;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RmFishing.Data
{
	public class BaitAndStamina
	{
		private readonly string _timingName;
		public readonly int Bait;
		public readonly int Stamina;
		private readonly bool _isPC;
		private readonly String _name;

		public BaitAndStamina(String timingName, Chara owner) {
			_isPC = owner.IsPC;
			_name = owner.Name;
			_timingName = timingName;
			Bait = _isPC ? EClass.player.eqBait.Num : 0;
			Stamina = _isPC ? EClass.player.chara.stamina.GetValue() : owner.stamina.GetValue();
		}

		[Conditional("DEBUG")]
		public void ShowData() {
			try {
				string message = _timingName + @"\n 対象：" + _name + "餌：" + Bait.ToString() + ", スタミナ" + Stamina.ToString();
				CommonUtil.OutputSimpleLog( message);
			} catch (Exception e) {
				CommonUtil.OutputErrorLog(e);
			}
		}
	}

}
