using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace Jolly_Pop_Injector
{
    public static class DLLInjector
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr processHandle,
        [Out, MarshalAs(UnmanagedType.Bool)] out bool wow64Process);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        public static IntPtr OpenProcess(Process proc, ProcessAccessFlags flags)
        {
            return OpenProcess(flags, false, proc.Id);
        }

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        public static bool IsProcess32Bit(IntPtr processHandle)
        {
            bool isWow64 = false;
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) || Environment.OSVersion.Version.Major > 5)
            {
                bool retVal;
                IsWow64Process(processHandle, out retVal);
                isWow64 = retVal;
            }
            return isWow64;
        }

        public static int InjectProcess(bool processIs32Bit, int PID, string DLL)
        {
            string exeToRun;
            DLL = DLL.Replace(@"\", "/");
            string args = string.Format("{0} \"{1}\"", PID.ToString(), DLL);
            MessageBox.Show(args);
            byte[] exeBytes;
            if (processIs32Bit)
            {
                exeToRun = Path.Combine(Path.GetTempPath(), "Injector_C++_32Bit.exe");
                exeBytes = Properties.Resources.Injector_C___32Bit;
            }
            else
            {
                exeToRun = Path.Combine(Path.GetTempPath(), "Injector_C++_64Bit.exe");
                exeBytes = Properties.Resources.Injector_C___64Bit;
            }

            using (FileStream exeFile = new FileStream(exeToRun, FileMode.Create))
            {
                exeFile.Write(exeBytes, 0, exeBytes.Length);
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exeToRun,
                    UseShellExecute = false,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            proc.WaitForExit();

            File.Delete(exeToRun);

            return proc.ExitCode;
        }

        public static int InjectDll(string targetProcessName, string dllName)
        {
            Process[] process = Process.GetProcessesByName(targetProcessName);
            int pid = process[0].Id;
            IntPtr pHandle = OpenProcess(ProcessAccessFlags.QueryInformation, false, pid);
            int res;

            if (IsProcess32Bit(pHandle))
            {
                //Process is 32 bit
                res = InjectProcess(true, pid, dllName);

            }
            else
            {
                //Process is 64 bit
                res = InjectProcess(false, pid, dllName);
            }
            MessageBox.Show(res.ToString());
            return res;
        }
    }
}
