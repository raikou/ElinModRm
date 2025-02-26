namespace RmModManagerWinForm
{
	partial class MainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			panel1 = new Panel();
			tableLayoutPanel1 = new TableLayoutPanel();
			label1 = new Label();
			label2 = new Label();
			button1 = new Button();
			button2 = new Button();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			splitContainer1 = new SplitContainer();
			groupBox1 = new GroupBox();
			dataGridView1 = new DataGridView();
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			tabPage2 = new TabPage();
			panel1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			tabControl1.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Controls.Add(tableLayoutPanel1);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(800, 64);
			panel1.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(label2, 0, 1);
			tableLayoutPanel1.Controls.Add(button1, 2, 0);
			tableLayoutPanel1.Controls.Add(button2, 2, 1);
			tableLayoutPanel1.Controls.Add(textBox1, 1, 0);
			tableLayoutPanel1.Controls.Add(textBox2, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Size = new Size(800, 64);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Dock = DockStyle.Fill;
			label1.Location = new Point(3, 0);
			label1.Name = "label1";
			label1.Size = new Size(94, 32);
			label1.TabIndex = 0;
			label1.Text = "Elin.exe Path";
			label1.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Dock = DockStyle.Fill;
			label2.Location = new Point(3, 32);
			label2.Name = "label2";
			label2.Size = new Size(94, 32);
			label2.TabIndex = 1;
			label2.Text = "Mod Path";
			label2.TextAlign = ContentAlignment.MiddleRight;
			// 
			// button1
			// 
			button1.BackColor = Color.FromArgb(192, 255, 192);
			button1.Dock = DockStyle.Fill;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Location = new Point(703, 3);
			button1.Name = "button1";
			button1.Size = new Size(94, 26);
			button1.TabIndex = 2;
			button1.Text = "参照";
			button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			button2.BackColor = Color.FromArgb(255, 255, 192);
			button2.Dock = DockStyle.Fill;
			button2.FlatStyle = FlatStyle.Flat;
			button2.Location = new Point(703, 35);
			button2.Name = "button2";
			button2.Size = new Size(94, 26);
			button2.TabIndex = 3;
			button2.Text = "参照";
			button2.UseVisualStyleBackColor = false;
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.Location = new Point(103, 3);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(594, 23);
			textBox1.TabIndex = 4;
			// 
			// textBox2
			// 
			textBox2.Dock = DockStyle.Fill;
			textBox2.Location = new Point(103, 35);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(594, 23);
			textBox2.TabIndex = 5;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 64);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(tabControl1);
			splitContainer1.Size = new Size(800, 386);
			splitContainer1.SplitterDistance = 266;
			splitContainer1.TabIndex = 1;
			splitContainer1.SplitterMoved += splitContainer1_SplitterMoved_1;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(dataGridView1);
			groupBox1.Dock = DockStyle.Fill;
			groupBox1.Location = new Point(0, 0);
			groupBox1.Margin = new Padding(6, 3, 3, 3);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(6, 3, 3, 3);
			groupBox1.Size = new Size(266, 386);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Enable Mod List";
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Dock = DockStyle.Fill;
			dataGridView1.Location = new Point(6, 19);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(257, 364);
			dataGridView1.TabIndex = 0;
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(530, 386);
			tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(522, 358);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "tabPage1";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(522, 358);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "tabPage2";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// MainWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(splitContainer1);
			Controls.Add(panel1);
			Name = "MainWindow";
			Text = "RmModManager";
			panel1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			tabControl1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private SplitContainer splitContainer1;
		private TableLayoutPanel tableLayoutPanel1;
		private Label label1;
		private Label label2;
		private Button button1;
		private Button button2;
		private TextBox textBox1;
		private TextBox textBox2;
		private GroupBox groupBox1;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private DataGridView dataGridView1;
	}
}
