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


		//**************�϶�**********************
		Point point; //��갴��ʱ�ĵ�
		bool isMoving = false;//��ʶ�Ƿ��϶�
		private void MainWindow_MouseDown(object sender, MouseEventArgs e)
		{
			point = e.Location;
			isMoving = true;//��ʶ�Ƿ��϶�
		}

		private void MainWindow_MouseUp(object sender, MouseEventArgs e)
		{
			isMoving = false;//��ʶ�Ƿ��϶�
		}
		private void MainWindow_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && isMoving)
			{
				Point pNew = new(e.Location.X - point.X, e.Location.Y - point.Y);
				Location = new Point(Location.X + pNew.X, Location.Y + pNew.Y);
			}
		}





		// �򿪺͹ر�Ximi��������
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
		/// ˫������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();//չʾ
		}


		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			switch (e.CloseReason)
			{
				case CloseReason.UserClosing:
					//�رմ��ڣ��������������ȡ���ر�
					if (stillAlive)
					{
						e.Cancel = true;
						Hide();
					}
					break;
			}
		}



		/// <summary>
		/// �����ܹر�Ŷ
		/// </summary>
		bool stillAlive = true;


		//ͨ���Ҽ����̾Ϳ��Թر���
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			stillAlive = false;
			Close();
		}

		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			notifyIcon1.Dispose();
		}

		//ͨ����ťҲ���Թر�
		private void ExitProgram(object sender, EventArgs e)
		{
			stillAlive = false;
			Close();
		}
	}
}
