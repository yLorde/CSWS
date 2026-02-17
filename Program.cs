using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace CSWS
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool LockWorkStation();

        private static readonly HashSet<string> _blockedApplications =
            new(StringComparer.OrdinalIgnoreCase);

        static void Main()
        {
            LoadBlockedApplications();

            Console.WriteLine("Monitorando aplicações...\n");

            while (true)
            {
                CheckForegroundApplication();
                Thread.Sleep(2000);
            }
        }

        private static void LoadBlockedApplications()
        {
            try
            {
                if (!File.Exists("blockedList.txt"))
                {
                    Console.WriteLine("Arquivo blockedList.txt não encontrado.");
                    return;
                }

                foreach (var line in File.ReadAllLines("blockedList.txt"))
                {
                    var app = line.Trim();
                    if (!string.IsNullOrWhiteSpace(app))
                        _blockedApplications.Add(app);
                }

                Console.WriteLine("Lista carregada:");
                foreach (var app in _blockedApplications)
                    Console.WriteLine(" - " + app);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao carregar lista: " + ex.Message);
            }
        }

        private static void CheckForegroundApplication()
        {
            IntPtr handle = GetForegroundWindow();

            if (handle == IntPtr.Zero)
                return;

            GetWindowThreadProcessId(handle, out uint pid);

            try
            {
                var process = Process.GetProcessById((int)pid);
                var processName = process.ProcessName + ".exe";

                Console.WriteLine("Em foco: " + processName);

                if (_blockedApplications.Contains(processName))
                {
                    Console.WriteLine("APLICAÇÃO BLOQUEADA DETECTADA!");

                    try
                    {
                        process.Kill();
                        Console.WriteLine("Processo encerrado.");
                    }
                    catch
                    {
                        Console.WriteLine("Não foi possível fechar. Bloqueando Windows.");
                        LockDesktop();
                    }
                }
            }
            catch
            {
                // processo pode ter fechado entre a leitura
            }
        }

        public static void LockDesktop()
        {
            if (!LockWorkStation())
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }
    }
}
