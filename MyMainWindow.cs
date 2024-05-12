using System.Runtime.InteropServices;

namespace ProjXimi
{
	public partial class MyMainWindow : Form
	{
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, UInt32 flags);
		public MyMainWindow()
		{
			InitializeComponent();
		}
		private void MainWindow_Shown(object sender, EventArgs e)
		{
			//ximi ??= new Ximi();
			//ximi.Show();
			schedule ??= new Schedule();
			schedule.Show();
			schedule.SendToBack();
			Hide();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{

		}

		Ximi? ximi;
		Schedule? schedule;


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
				Point pNew = new(e.Location.X - point.X, e.Location.Y - point.Y);
				Location = new Point(Location.X + pNew.X, Location.Y + pNew.Y);
			}
		}





		// 打开和关闭Ximi悬浮窗口
		private void OpenXimi(object sender, EventArgs e)
		{
			ximi ??= new Ximi();
			if (ximi.IsDisposed)
			{
				ximi = new Ximi();
			}
			ximi.Show();
		}
		private void CloseXimi(object sender, EventArgs e)
		{
			ximi ??= new Ximi();
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
		private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();//展示
		}


		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			switch (e.CloseReason)
			{
				case CloseReason.UserClosing:
					//关闭窗口？如果不想死，就取消关闭
					if (stillAlive)
					{
						e.Cancel = true;
						Hide();
					}
					break;
			}
		}



		/// <summary>
		/// 还不能关闭哦
		/// </summary>
		bool stillAlive = true;


		//通过右键托盘就可以关闭了
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			stillAlive = false;
			Close();
		}

		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			notifyIcon1.Dispose();
		}

		//通过大按钮也可以关闭
		private void ExitProgram(object sender, EventArgs e)
		{
			stillAlive = false;
			Close();
		}
	}
}
