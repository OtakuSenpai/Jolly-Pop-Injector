namespace Jolly_Pop_Injector
{
    public class SettingsHandler
    {
        public int AutoInject { get; set; } = 0;
        public int CloseAfterInjection { get; set; } = 0;
        public int SaveProcessName { get; set; } = 1;
        public int SaveDLLlocation { get; set; } = 1;
        public int SilentStart { get; set; } = 0;
        public string Process { get; set; } = "Not set";
        public string DLL { get; set; } = "Not set";
    }
}
