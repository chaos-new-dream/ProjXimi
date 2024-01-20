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
			components = new System.ComponentModel.Container();
			pictureBox1 = new PictureBox();
			timer1 = new System.Windows.Forms.Timer(components);
			label1 = new Label();
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
			// timer1
			// 
			timer1.Enabled = true;
			timer1.Tick += timer1_Tick;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top;
			label1.AutoSize = true;
			label1.BackColor = Color.White;
			label1.Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(154, 255);
			label1.Name = "label1";
			label1.Size = new Size(189, 90);
			label1.TabIndex = 1;
			label1.Text = "大写锁定已经打开\r\n数字锁定已经关闭\r\n滚动锁定已经打开";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			label1.Click += label1_Click;
			label1.MouseDown += Ximi_MouseDown;
			label1.MouseMove += Ximi_MouseMove;
			label1.MouseUp += Ximi_MouseUp;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(224, 170);
			label2.Name = "label2";
			label2.Size = new Size(47, 17);
			label2.TabIndex = 2;
			label2.Text = "Debug";
			// 
			// Ximi
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(499, 388);
			Controls.Add(label2);
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
		private System.Windows.Forms.Timer timer1;
		private Label label1;
		private Label label2;
	}
}