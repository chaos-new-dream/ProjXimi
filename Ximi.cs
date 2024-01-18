using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjXimi
{
	public partial class Ximi : Form
	{
		public Ximi()
		{
			InitializeComponent();
			//GotFocus += pictureBox1.GotFocus;
			//LostFocus += pictureBox1.LostFocus;
		}

		private void Ximi_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		Point point; //鼠标按下时的点
		bool isMoving = false;//标识是否拖动


		private void Ximi_MouseDown(object sender, MouseEventArgs e)
		{
			//MessageBox.Show("cnm");
			point = e.Location;
			isMoving = true;//标识是否拖动
			pictureBox1.Image = Properties.Resources.zouFullClicking;
		}

		private void Ximi_MouseUp(object sender, MouseEventArgs e)
		{
			isMoving = false;//标识是否拖动
			pictureBox1.Image = Properties.Resources.zouFull;
		}

		private void Ximi_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && isMoving)
			{
				Point pNew = new Point(e.Location.X - point.X, e.Location.Y - point.Y);
				Location = new Point(Location.X + pNew.X, Location.Y + pNew.Y);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			string toShow = "";
			if (IsKeyLocked(Keys.CapsLock))
			{
				toShow += "大写锁定已经打开\n";
			}
			if (!IsKeyLocked(Keys.NumLock))
			{
				toShow += "数字锁定已经关闭\n";
			}
			if (IsKeyLocked(Keys.Scroll))
			{
				toShow += "滚动锁定已经打开\n";
			}
			label1.Text = toShow;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}



		//**********引用Win32程序****************
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
		//***************Win32的常量*********************
		private const uint WM_CLOSE = 0x0010;
		private const uint WM_SYSCOMMAND = 0x0112;
		private const int SC_MAXIMIZE = 0xF030;


		// EnumWindows回调函数委托  
		private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
		private bool CloseExplorerWindow(IntPtr hWnd, IntPtr lParam)
		{
			const int nChars = 256;
			StringBuilder Buff = new StringBuilder(nChars);
			// 如果窗口类名是"CabinetWClass"，则关闭它  
			if (GetClassName(hWnd, Buff, nChars) > 0)
			{
				if (Buff.ToString() == "CabinetWClass")
				{
					PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
				}
			}
			// 继续枚举下一个窗口
			return true;
		}



		private void Ximi_KeyDown(object sender, KeyEventArgs e)
		{
			if (isMoving)
			{
				switch (e.KeyCode)
				{
					case Keys.F4:
						EnumWindows(new EnumWindowsProc(CloseExplorerWindow), IntPtr.Zero);
						//while (true){
						//	IntPtr hWnd = FindWindow("CabinetWClass", null);
						//	if (hWnd != IntPtr.Zero)
						//	{
						//		PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
						//		//PostMessage(hWnd, WM_SYSCOMMAND, (IntPtr)SC_MAXIMIZE, IntPtr.Zero);
						//	}
						//	else
						//		break;
						//}
						break;
				}
			}
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
