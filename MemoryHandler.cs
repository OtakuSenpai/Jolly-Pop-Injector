using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

/*
    -MemoryHandler-
    This class should allow access to a processes memory, and allow reading from
    and writing to it.
*/
namespace Jolly_Pop_Injector
{
    public static class MemoryHandler
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        public static int GetPID(string processname)
        { //Return the PID of the requested process. Needs exception handling.
            Process[] process = Process.GetProcessesByName(processname);
            int PID = process[0].Id;

            return PID;
        }

        public static IntPtr getBaseAddr(string processname)
        { //Return the base address of the requested process.
            IntPtr baseaddr;
            try
            {
                Process[] processes = Process.GetProcessesByName(processname);
                baseaddr = processes[0].MainModule.BaseAddress;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return (IntPtr)0;
            }

            return baseaddr;
        }

        public static IntPtr GetProcessHandleByName(string processname)
        {
            Process process = Process.GetProcessesByName(processname)[0];
            IntPtr ProcessHandle = OpenProcess(AccessRights.PROCESS_WM_READ | AccessRights.PROCESS_VM_WRITE | AccessRights.PROCESS_VM_OPERATION, false, process.Id);
            return ProcessHandle;
        }

        /*
            -WriteToProcessMemory-
            Return value 1: Access Denied.
            Return value 0: Success
            Otherwise, error code is returned.
        */
        public static int WriteToProcessAddress(string processname, int address, byte[] value)
        {
            IntPtr processHandle = GetProcessHandleByName(processname);
            IntPtr baseAddr = getBaseAddr(processname);
            if ((int)baseAddr == 0)
            {
                return 1;
            }

            IntPtr addr = IntPtr.Add(baseAddr, address);
            int bytesWritten = 0;

            if (!WriteProcessMemory(processHandle, addr, value, value.Length, out bytesWritten))
            {
                return Marshal.GetLastWin32Error();
            }
            return 0;
        }

        public static int WriteToProcessMemory(string processname, IntPtr address, byte[] value)
        {
            IntPtr processHandle = GetProcessHandleByName(processname);
            int bytesWritten = 0;
            string shit = "f.dll";
            if (!WriteProcessMemory(processHandle, address, value, (int)((shit.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten))
            {
                return Marshal.GetLastWin32Error();
            }
            return 0;
        }
    }
}
