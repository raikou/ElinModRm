using System;
using System.Windows.Forms;

namespace RmModManager
{
	public partial class MainWindow : Form
	{
		public MainWindow() {
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {
			this.button1.Text += "clilked!";
		}
	}
}
