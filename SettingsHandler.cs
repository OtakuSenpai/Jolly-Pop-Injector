using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jolly_Pop_Injector {
    public class SettingsHandler {
        public float AutoInject { get; set; } = 1;
        public float CloseAfterInjection { get; set; } = 1;
        public int SaveProcessName { get; set; } = 1;
        public int SaveDLLlocation { get; set; } = 1;
        public string Process { get; set; } = "Not set";
        public string DLL { get; set; } = "Not set";
    }
}
