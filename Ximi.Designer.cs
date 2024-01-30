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
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::ProjXimi.Properties.Resources.zouFull;
			this.pictureBox1.Location = new System.Drawing.Point(377, 227);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(60, 80);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ximi_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ximi_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ximi_MouseUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(330, 262);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 81);
			this.label1.TabIndex = 1;
			this.label1.Text = "大写锁定打开\r\n数字锁定关闭\r\n滚动锁定打开";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(443, 197);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 32);
			this.label2.TabIndex = 2;
			this.label2.Text = "RAM: 27.0%\r\nCPU:  0.9%";
			// 
			// label_debug
			// 
			this.label_debug.AutoSize = true;
			this.label_debug.BackColor = System.Drawing.Color.WhiteSmoke;
			this.label_debug.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_debug.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label_debug.Location = new System.Drawing.Point(332, 192);
			this.label_debug.Name = "label_debug";
			this.label_debug.Size = new System.Drawing.Size(47, 16);
			this.label_debug.TabIndex = 3;
			this.label_debug.Text = "Debug";
			// 
			// Ximi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label_debug);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Ximi";
			this.ShowInTaskbar = false;
			this.Text = "Form1";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.White;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label_debug;
	}
}