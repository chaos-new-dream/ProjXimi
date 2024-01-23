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
		//**********引用Win32程序****************
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern bool LockWorkStation();//调用windows的系统锁定 

		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, uint wParam, uint lParam);





		//***************Win32的常量*********************
		private const uint WM_CLOSE = 0x0010;
		private const uint WM_SYSCOMMAND = 0x0112;
		private const uint SC_MAXIMIZE = 0xF030;
		private const uint SC_MONITORPOWER = 0xF170;
		private const uint APPCOMMAND_VOLUME_MUTE = 0x80000;
		private const uint APPCOMMAND_VOLUME_UP = 0xA0000;
		private const uint APPCOMMAND_VOLUME_DOWN = 0x90000;
		private const uint WM_APPCOMMAND = 0x319;


		System.Windows.Forms.Timer each1sTimer;
		System.Windows.Forms.Timer lockScreenTimer;
		System.Windows.Forms.Timer mainTimer;


		PerformanceCounter ramCounter;
		PerformanceCounter cpuCounter;
		PerformanceCounter diskCounter;
		public Ximi()
		{
			InitializeComponent();

			ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
			cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
			diskCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");

			// 初始化计时器
			if (lockScreenTimer != null)
				MessageBox.Show("lockScreenTimer初始值不为Null", "Error");
			lockScreenTimer = new System.Windows.Forms.Timer();
			lockScreenTimer.Interval = 3000;
			lockScreenTimer.Tick += delegate
			{
				LockWorkStation();
				SendMessage(Handle, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
				lockScreenTimer.Stop();
			};

			// 初始化显示系统信息计时器
			if (each1sTimer != null)
				MessageBox.Show("topmostTimer初始值不为Null", "Error");
			each1sTimer = new System.Windows.Forms.Timer();
			each1sTimer.Interval = 1000;
			each1sTimer.Tick += delegate
			{
				TopMost = true;
				label2.Text = "";
				label2.Text += "RAM: " + $"{ramCounter.NextValue():0.0}%".PadLeft(6) + "\n";
				label2.Text += "CPU: " + $"{cpuCounter.NextValue():0.0}%".PadLeft(6) + "\n";
				label2.Text += "Disk:" + $"{diskCounter.NextValue():0.0}%".PadLeft(6) + "\n";
			};
			each1sTimer.Start();//立即启动

			// 初始化键盘计时器
			if (mainTimer != null)
				MessageBox.Show("mainTimer初始值不为Null", "Error");
			mainTimer = new System.Windows.Forms.Timer();
			mainTimer.Interval = 100;
			mainTimer.Tick += delegate
			{
				string toShow = "";
				if (IsKeyLocked(Keys.CapsLock))
				{
					toShow += "大写锁定打开\n";
				}
				if (!IsKeyLocked(Keys.NumLock))
				{
					toShow += "数字锁定关闭\n";
				}
				if (IsKeyLocked(Keys.Scroll))
				{
					toShow += "滚动锁定打开\n";
				}
				label1.Text = toShow;
			};
			mainTimer.Start();//立即启动
		}
		private void Ximi_Load(object sender, EventArgs e)
		{
			label_debug.Text = "";
			// 添加鼠标滚轮事件
			pictureBox1.MouseWheel += Ximi_MouseWheel;
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

		private void UpMouse()
		{
			isMoving = false;//标识是否拖动
			pictureBox1.Image = Properties.Resources.zouFull;
		}

		private void Ximi_MouseUp(object sender, MouseEventArgs e)
		{
			UpMouse();
		}

		private void Ximi_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && isMoving)
			{
				Point pNew = new Point(e.Location.X - point.X, e.Location.Y - point.Y);
				Location = new Point(Location.X + pNew.X, Location.Y + pNew.Y);
			}
		}

		// 滚轮调音量
		private void Ximi_MouseWheel(object? sender, MouseEventArgs e)
		{
			if (isMoving)
			{
				if (e.Delta > 0)
				{
					SendMessage(Handle, WM_APPCOMMAND, 0, APPCOMMAND_VOLUME_UP);
				}
				else
				{
					SendMessage(Handle, WM_APPCOMMAND, 0, APPCOMMAND_VOLUME_DOWN);
				}
			}
		}




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
					case Keys.F1:
						MessageBox.Show("F4:关闭所有文件夹\nL:3秒后锁屏\n滚轮调节音量", "提示");
						break;
					case Keys.F4:
						EnumWindows(new EnumWindowsProc(CloseExplorerWindow), IntPtr.Zero);
						break;
					case Keys.L:
						lockScreenTimer.Start();
						break;
				}
				UpMouse();
			}
		}


		private void Ximi_FormClosed(object sender, FormClosedEventArgs e)
		{
			lockScreenTimer?.Dispose();
			each1sTimer?.Dispose();
			mainTimer?.Dispose();

			ramCounter?.Dispose();
			cpuCounter?.Dispose();
			diskCounter?.Dispose();
		}
	}
}
