﻿#define useGPU

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
using System.Threading;

#if useGPU
using ManagedCuda.Nvml;
using ManagedCuda.BasicTypes;
#endif
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
		// 设置此窗体为活动窗体：
		// 将创建指定窗口的线程带到前台并激活该窗口。键盘输入直接指向窗口，并为用户更改各种视觉提示。
		// 系统为创建前台窗口的线程分配的优先级略高于其他线程。
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
		// 设置此窗体为活动窗体：
		// 激活窗口。窗口必须附加到调用线程的消息队列。
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		public static extern IntPtr SetActiveWindow(IntPtr hWnd);
		// 设置窗体位置
		[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, UInt32 flags);



		//***************Win32的常量*********************
		private const uint WM_CLOSE = 0x0010;
		private const uint WM_SYSCOMMAND = 0x0112;
		private const uint SC_MAXIMIZE = 0xF030;
		private const uint SC_MONITORPOWER = 0xF170;
		private const uint APPCOMMAND_VOLUME_MUTE = 0x80000;
		private const uint APPCOMMAND_VOLUME_UP = 0xA0000;
		private const uint APPCOMMAND_VOLUME_DOWN = 0x90000;
		private const uint WM_APPCOMMAND = 0x319;
		private static IntPtr HWND_TOPMOST = new IntPtr(-1);
		private static IntPtr HWND_NOTOPMOST = new IntPtr(-2);
		private const UInt32 SWP_NOSIZE = 0x0001;
		private const UInt32 SWP_NOMOVE = 0x0002;
		private const UInt32 SWP_SHOWWINDOW = 0x0040;

		//计时器
		readonly System.Windows.Forms.Timer each1sTimer;
		readonly System.Windows.Forms.Timer lockScreenTimer;
		readonly System.Windows.Forms.Timer mainTimer;

		//传感器
		readonly PerformanceCounter ramCounter;
		readonly PerformanceCounter cpuCounter;
		readonly PerformanceCounter diskCounter;

#if useGPU
		private nvmlDevice nvml_Device;
		nvmlUtilization nvml_Utilization;
#endif
		//1分钟左右置顶一次
		//321
		const int BringToFrontMaxNum = 60;
		int bringToFront = 0;

		public Ximi()
		{
			InitializeComponent();

			label_debug.Text = "";

			pictureBox1.MouseDown += Ximi_MouseDown;
			pictureBox1.MouseMove += Ximi_MouseMove;
			pictureBox1.MouseUp += Ximi_MouseUp;
			label1.MouseDown += Ximi_MouseDown;
			label1.MouseMove += Ximi_MouseMove;
			label1.MouseUp += Ximi_MouseUp;
			label2.MouseDown += Ximi_MouseDown;
			label2.MouseMove += Ximi_MouseMove;
			label2.MouseUp += Ximi_MouseUp;
			pictureBox1.MouseWheel += Ximi_MouseWheel;


			ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
			cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
			diskCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
			//gpuCounter = new PerformanceCounter("GPU Engine", "% Utilization");


#if useGPU
			if (NvmlNativeMethods.nvmlInit() != ManagedCuda.Nvml.nvmlReturn.Success)
			{
				throw new Exception("初始化NVML失败");
			}
			NvmlNativeMethods.nvmlDeviceGetHandleByIndex(0, ref nvml_Device);
			nvml_Utilization = new nvmlUtilization();
#endif
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
				// TopMost = true;
				if (bringToFront > 0)
				{
					bringToFront--;
				}
				else
				{
					bringToFront = BringToFrontMaxNum;
					BringToFront();
				}

#if useGPU
				if (NvmlNativeMethods.nvmlDeviceGetUtilizationRates(nvml_Device, ref nvml_Utilization) != ManagedCuda.Nvml.nvmlReturn.Success)
				{
					throw new Exception("获得失败");
				}
#endif

				label2.Text = "";
				label2.Text += "RAM: " + $"{ramCounter.NextValue():0.0}%".PadLeft(6) + "\n";
				label2.Text += "CPU: " + $"{cpuCounter.NextValue():0.0}%".PadLeft(6) + "\n";
				label2.Text += "磁盘:" + $"{diskCounter.NextValue():0.0}%".PadLeft(6) + "\n";

#if useGPU
				label2.Text += "GPU: " + $"{nvml_Utilization.gpu:0.0}%".PadLeft(6) + "\n";
				label2.Text += "显存:" + $"{nvml_Utilization.memory:0.0}%".PadLeft(6) + "\n";
#endif

				label_debug.Text = "";
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

			//SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
			// 设置本窗体为活动窗体
			//SetActiveWindow(this.Handle);
			//SetForegroundWindow(this.Handle);
			// 设置窗体置顶
		}


		Point point; //鼠标按下时的点
		bool isMoving = false;//标识是否拖动

		private void Ximi_MouseDown(object? sender, MouseEventArgs e)
		{
			//MessageBox.Show("cnm");
			point = e.Location;
			isMoving = true;//标识是否拖动
			pictureBox1.Image.Dispose();
			pictureBox1.Image = Properties.Resources.zouFullClicking;
		}

		private void UpMouse()
		{
			isMoving = false;//标识是否拖动
			pictureBox1.Image.Dispose();
			pictureBox1.Image = Properties.Resources.zouFull;
		}

		private void Ximi_MouseUp(object? sender, MouseEventArgs e)
		{
			UpMouse();
		}

		private void Ximi_MouseMove(object? sender, MouseEventArgs e)
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
			//myComputer?.Close();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
