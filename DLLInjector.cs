using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Jolly_Pop_Injector
{
    public class DLLInjector
    {
        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, int lpNumberOfBytesWritten);

        public static int InjectDLL(string target_process_name, string DLLName)
        {
            //CreateRemoteThread to LoadLibraryA()
            Process[] process = Process.GetProcessesByName(target_process_name);

            int PID = process[0].Id;

            IntPtr process_handle = OpenProcess(PROCESS_WM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, PID);
            IntPtr LoadLibraryAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            IntPtr AddressToWrite = VirtualAllocEx(process_handle, (IntPtr)null, (IntPtr)DLLName.Length, MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);

            byte[] bytes = Encoding.ASCII.GetBytes(DLLName);
            WriteProcessMemory(process_handle, AddressToWrite, bytes, (uint)bytes.Length, 0);
            CreateRemoteThread(process_handle, (IntPtr)null, IntPtr.Zero, LoadLibraryAddress, AddressToWrite, 0, (IntPtr)null);

            return 1;

        }
    }
}
