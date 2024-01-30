using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjXimi
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow_Shown(object sender, EventArgs e)
		{
			ximi = new Ximi();
			ximi.Show();
			Hide();
		}



		//**************拖动**********************
		Point point; //鼠标按下时的点
		bool isMoving = false;//标识是否拖动
		private void MainWindow_MouseDown(object sender, MouseEventArgs e)
		{
			point = e.Location;
			isMoving = true;//标识是否拖动
		}

		private void MainWindow_MouseUp(object sender, MouseEventArgs e)
		{
			isMoving = false;//标识是否拖动
		}
		private void MainWindow_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && isMoving)
			{
				Point pNew = new Point(e.Location.X - point.X, e.Location.Y - point.Y);
				Location = new Point(Location.X + pNew.X, Location.Y + pNew.Y);
			}
		}


		private void MainWindow_Load(object sender, EventArgs e)
		{
		}




		// 打开和关闭Ximi悬浮窗口
		Ximi ximi;
		private void button1_Click(object sender, EventArgs e)
		{
			if (ximi.IsDisposed)
			{
				ximi = new Ximi();
			}
			ximi.Show();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			if (ximi.IsDisposed)
			{
				ximi = new Ximi();
			}
			ximi.Hide();
		}

		/// <summary>
		/// 双击托盘
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();//展示
			ShowInTaskbar = true;
		}

		private void MainWindow_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				ShowInTaskbar = false;
			}
		}


		//private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		//{
		//	switch (e.CloseReason)
		//	{
		//		case CloseReason.UserClosing:
		//			//关闭窗口？如果不想死，就取消关闭
		//			if (stillAlive)
		//			{
		//				e.Cancel = true;
		//				Hide();
		//			}
		//			break;
		//	}
		//}



		///// <summary>
		///// 还不能关闭哦
		///// </summary>
		//bool stillAlive = true;


		////通过右键托盘就可以关闭了
		//private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//	stillAlive = false;
		//	Close();
		//}

		//private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		//{
		//	notifyIcon1.Dispose();
		//}

		////通过大按钮也可以关闭
		//private void button3_Click(object sender, EventArgs e)
		//{
		//	stillAlive = false;
		//	Close();
		//}

	}
}
