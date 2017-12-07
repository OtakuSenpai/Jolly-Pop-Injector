using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Jolly_Pop_Injector {
    public static class ProcessHandler {
        public static bool ProcessIsRunning(string process_name) { //If user passes process name with ".exe",
            if (process_name.Substring(process_name.Length - 4) == ".exe") {
                process_name = process_name.Substring(0, process_name.Length - 4); //Strip it out
            }
            Process[] pname = Process.GetProcessesByName(process_name);
            if (pname.Length != 0)
                return true;
            else
                return false;
        }
    }
}
