using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jolly_Pop_Injector
{
    public static class AccessRights //Not all of these flags are used. They're there just incase I need them.
    {
        public static int PROCESS_WM_READ { get; } = 0x0010;
        public static int PROCESS_VM_WRITE { get; } = 0x0020;
        public static int PROCESS_VM_OPERATION { get; } = 0x0008;
        public static int PROCESS_CREATE_THREAD { get; } = 0x0002;
        public static int PROCESS_CREATE_PROCESS { get; } = 0x0080;
        public static int PROCESS_QUERY_INFORMATION { get; } = 0x0400;
        public static int PROCESS_DUP_HANDLE { get; } = 0x0040;
        public static int PROCESS_QUERY_LIMITED_INFORMATION { get; } = 0x1000;
        public static int PROCESS_SET_INFORMATION { get; } = 0x0200;
        public static int PROCESS_SET_QUOTA { get; } = 0x0100;
        public static int PROCESS_SUSPEND_RESUME { get; } = 0x0800;
        public static int PROCESS_TERMINATE { get; } = 0x0001;
        public static long SYNCHRONIZE { get; } = 0x00100000L;

        public static uint MEM_COMMIT { get; } = 0x00001000;
        public static uint MEM_RESERVE { get; } = 0x00002000;
        public static uint PAGE_READWRITE { get; } = 4;
    }
}
