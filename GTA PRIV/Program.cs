using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace GTA_PRIV
{
    class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        static void Main(string[] args)
        {
            Console.Title = "GTA V Private Session Joiner | By: Vortexx/ZipTop";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Checking if GTA V is open...\n");
            Process[] pname = Process.GetProcessesByName("GTA5");
            if (pname.Length > 0)
            {
                var pID = pname[0].Id;
                Console.WriteLine($"GTA V Found! (pID: {pID}) Press Enter to Start Private Server...");
                Console.ReadKey();
                Start:
                Console.Clear();
                try
                {
                    Console.WriteLine("Pausing Process...");
                    var process = Process.GetProcessById(pID);
                    process.Suspend();
                    Console.WriteLine("Process Paused! Finding Server...");
                    Thread.Sleep(10000);
                    process.Resume();
                    Console.WriteLine("Joing Empty Server...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Empty Server Joined! Tabbing back in 1 second!\nMADE BY VORTEXX/ZIPTOP!\n\nPress Enter to Close Program or 'R' to Rejoin a Private Session");
                    Thread.Sleep(1000);
                    SetForegroundWindow(pname[0].MainWindowHandle);
                    var key = Console.ReadKey().Key;
                    if (key== ConsoleKey.R)
                    {
                        //System.Diagnostics.Process.Start(Application.ExecutablePath);
                        //Environment.Exit(0);
                        goto Start;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("THERE WAS AN ERROR! Press Enter To Exit...");
                    Console.ReadKey();
                }
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("GTA V IS NOT RUNNING! Press Enter To Exit...");
                Console.ReadKey();
            }
        }
    }

    [Flags]
    public enum ThreadAccess : int
    {
        TERMINATE = (0x0001),
        SUSPEND_RESUME = (0x0002),
        GET_CONTEXT = (0x0008),
        SET_CONTEXT = (0x0010),
        SET_INFORMATION = (0x0020),
        QUERY_INFORMATION = (0x0040),
        SET_THREAD_TOKEN = (0x0080),
        IMPERSONATE = (0x0100),
        DIRECT_IMPERSONATION = (0x0200)
    }
    public static class ProcessExtension
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [DllImport("kernel32.dll")]
        static extern uint SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll")]
        static extern int ResumeThread(IntPtr hThread);

        public static void Suspend(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (pOpenThread == IntPtr.Zero)
                {
                    break;
                }
                SuspendThread(pOpenThread);
            }
        }
        public static void Resume(this Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                var pOpenThread = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (pOpenThread == IntPtr.Zero)
                {
                    break;
                }
                ResumeThread(pOpenThread);
            }
        }
    }
}