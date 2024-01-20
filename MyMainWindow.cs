namespace ProjXimi
{
	public partial class MyMainWindow : Form
	{
		public MyMainWindow()
		{
			ximi = new Ximi();
			InitializeComponent();
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
			ximi.Show();
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
		}


		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			switch(e.CloseReason)
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

		private void MainWindow_Shown(object sender, EventArgs e)
		{
			Hide();
		}

		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			notifyIcon1.Dispose();
		}
	}
}
