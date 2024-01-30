namespace ProjXimi
{
	partial class MainWindow
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.exitToolStripMenuItem.Text = "退出";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button1.Location = new System.Drawing.Point(22, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 45);
			this.button1.TabIndex = 1;
			this.button1.Text = "打开Ximi";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.button2.Location = new System.Drawing.Point(22, 63);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 45);
			this.button2.TabIndex = 2;
			this.button2.Text = "关闭Ximi";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.Text = "Ximi控制台";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.Shown += new System.EventHandler(this.MainWindow_Shown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
			this.Resize += new System.EventHandler(this.MainWindow_Resize);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}

