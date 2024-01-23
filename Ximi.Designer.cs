namespace ProjXimi
{
	partial class Ximi
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pictureBox1 = new PictureBox();
			label1 = new Label();
			label_debug = new Label();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// pictureBox1
			// 
			pictureBox1.BackColor = Color.Transparent;
			pictureBox1.Image = Properties.Resources.zouFull;
			pictureBox1.Location = new Point(200, 200);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(90, 120);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox1.MouseDown += Ximi_MouseDown;
			pictureBox1.MouseMove += Ximi_MouseMove;
			pictureBox1.MouseUp += Ximi_MouseUp;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top;
			label1.AutoSize = true;
			label1.BackColor = Color.WhiteSmoke;
			label1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(171, 250);
			label1.Name = "label1";
			label1.Size = new Size(145, 90);
			label1.TabIndex = 1;
			label1.Text = "大写锁定打开\r\n数字锁定关闭\r\n滚动锁定打开";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			label1.MouseDown += Ximi_MouseDown;
			label1.MouseMove += Ximi_MouseMove;
			label1.MouseUp += Ximi_MouseUp;
			// 
			// label_debug
			// 
			label_debug.AutoSize = true;
			label_debug.Location = new Point(224, 170);
			label_debug.Name = "label_debug";
			label_debug.Size = new Size(47, 17);
			label_debug.TabIndex = 2;
			label_debug.Text = "Debug";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.WhiteSmoke;
			label2.Font = new Font("黑体", 9F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(293, 200);
			label2.Name = "label2";
			label2.Size = new Size(53, 36);
			label2.TabIndex = 3;
			label2.Text = "RAM: 32%\r\nCPU:  1%\r\nDisk: 2%";
			// 
			// Ximi
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(499, 388);
			Controls.Add(label2);
			Controls.Add(label_debug);
			Controls.Add(label1);
			Controls.Add(pictureBox1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "Ximi";
			ShowInTaskbar = false;
			Text = "Ximi";
			TopMost = true;
			TransparencyKey = Color.White;
			FormClosed += Ximi_FormClosed;
			Load += Ximi_Load;
			KeyDown += Ximi_KeyDown;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pictureBox1;
		private Label label1;
		private Label label_debug;
		private Label label2;
	}
}