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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label_debug = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
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
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top;
			label1.AutoSize = true;
			label1.BackColor = Color.WhiteSmoke;
			label1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(145, 200);
			label1.Name = "label1";
			label1.Size = new Size(145, 90);
			label1.TabIndex = 1;
			label1.Text = "大写锁定打开\r\n数字锁定关闭\r\n滚动锁定打开";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label_debug
			// 
			label_debug.AutoSize = true;
			label_debug.Location = new Point(293, 303);
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
			label2.Size = new Size(53, 60);
			label2.TabIndex = 3;
			label2.Text = "RAM: 32%\r\nCPU:  1%\r\n磁盘: 2%\r\nGPU:  0%\r\n显存: 0%";
			label2.Click += label2_Click;
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
			KeyDown += Ximi_KeyDown;
			MouseDown += Ximi_MouseDown;
			MouseMove += Ximi_MouseMove;
			MouseUp += Ximi_MouseUp;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label_debug;
	}
}