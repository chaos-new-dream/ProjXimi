namespace ProjXimi
{
	partial class MyMainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMainWindow));
			notifyIcon1 = new NotifyIcon(components);
			contextMenuStrip1 = new ContextMenuStrip(components);
			ExitToolStripMenuItem = new ToolStripMenuItem();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// notifyIcon1
			// 
			notifyIcon1.ContextMenuStrip = contextMenuStrip1;
			notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
			notifyIcon1.Text = "Ximi";
			notifyIcon1.Visible = true;
			notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { ExitToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(101, 26);
			// 
			// ExitToolStripMenuItem
			// 
			ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			ExitToolStripMenuItem.Size = new Size(100, 22);
			ExitToolStripMenuItem.Text = "退出";
			ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
			// 
			// button1
			// 
			button1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			button1.Location = new Point(23, 12);
			button1.Name = "button1";
			button1.Size = new Size(171, 54);
			button1.TabIndex = 0;
			button1.Text = "打开悬浮窗";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			button2.Location = new Point(23, 72);
			button2.Name = "button2";
			button2.Size = new Size(171, 54);
			button2.TabIndex = 1;
			button2.Text = "关闭悬浮窗";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
			button3.Location = new Point(348, 242);
			button3.Name = "button3";
			button3.Size = new Size(171, 54);
			button3.TabIndex = 2;
			button3.Text = "退出程序";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// MyMainWindow
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(531, 308);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(button1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MyMainWindow";
			Text = "Ximi";
			TopMost = true;
			FormClosing += MainWindow_FormClosing;
			FormClosed += MainWindow_FormClosed;
			Load += MainWindow_Load;
			Shown += MainWindow_Shown;
			MouseDown += MainWindow_MouseDown;
			MouseMove += MainWindow_MouseMove;
			MouseUp += MainWindow_MouseUp;
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private NotifyIcon notifyIcon1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem ExitToolStripMenuItem;
		private Button button1;
		private Button button2;
		private Button button3;
	}
}
