using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;
using System.ComponentModel;

class Program
{
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern bool LockWorkStation();

    public static List<string> BlockedList = new();

    static void Main()
    {
        UpdateBlockedList();

        while (true)
        {
            Console.WriteLine("Checking...");

            // AllProcesses();
            ApplicationInFocus();

            Thread.Sleep(2000);
        }
    }

    static void UpdateBlockedList()
    {
        Console.WriteLine("Atualizando lista...");
        BlockedList.Clear();
        string[] blockList = File.ReadAllText("blockedList.txt").Split(',');
        blockList.ToList().ForEach(x => BlockedList.Add(x));
    }

    // Comming soon
    static void AllProcesses()
    {
        var activeProcesses = new HashSet<int>();


        var currentProcesses = Process.GetProcesses();

        foreach (var p in currentProcesses)
        {
            if (!activeProcesses.Contains(p.Id))
            {
                activeProcesses.Add(p.Id);
            }
        }

        activeProcesses.RemoveWhere(id =>
        {
            try
            {
                return Process.GetProcessById(id) == null;
            }
            catch
            {
                return true;
            }
        });
    }

    static void ApplicationInFocus()
    {
        IntPtr handle = GetForegroundWindow();
        StringBuilder buffer = new StringBuilder(256);
        if (GetWindowText(handle, buffer, 256) > 0)
            BlockedList.ForEach(x =>
            {
                string[] splitedName = buffer.ToString().Split();
                splitedName.ToList().ForEach(y =>
                {
                    if (x.Contains(y, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine("Aplicação proibida em foco: " + buffer.ToString());
                        LockDesktop();
                    }
                });
            });
    }

    public static void LockDesktop()
    {
        bool result = LockWorkStation();
        if (result == false)
        {
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }
    }
}