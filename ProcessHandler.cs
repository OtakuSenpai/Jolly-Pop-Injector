using System.Diagnostics;

namespace Jolly_Pop_Injector
{
    public static class ProcessHandler
    {
        public static bool ProcessIsRunning(string processName)
        { //If user passes process name with ".exe",
            if (processName.Contains(".exe"))
            {
                processName = processName.Substring(0, processName.Length - 4); //Strip it out
            }
            Process[] pname = Process.GetProcessesByName(processName);
            if (pname.Length != 0)
                return true;
            else
                return false;
        }
    }
}
