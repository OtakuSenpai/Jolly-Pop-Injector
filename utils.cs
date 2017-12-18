using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;

namespace Jolly_Pop_Injector
{
    public static class Utils
    {
        public static bool IsAdministrator()
        { //Detects if the user is admin or not (dur)
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void LoadSettings(SettingsHandler settings, int context) //Pass the context so if I need to call SerializeSettings, I will have something to pass it.
        { //For loading settings from the XML file.
            SettingsHandler loadedSettings = XmlHandler.DeSerialize_Settings();
            if (loadedSettings == null)
            {
                string dialogResult;
                if (!XmlHandler.XmlExists())
                {
                    if (settings.SilentStart == 0)
                    {
                        dialogResult = "I did not find an XML config file. A new one will be generated with default values.";
                        MessageBox.Show(dialogResult);
                    }
                }
                else
                {
                    dialogResult = "An XML config file was found, but I failed to load it properly. It is possible it is damaged. A new one will be generated.";
                    MessageBox.Show(dialogResult);
                    FileInfo fi = new FileInfo(XmlHandler.XmlPath);
                    if (fi.IsReadOnly && IsAdministrator()) //If the file is readonly for some reason, that will cause an unauthorizedaccessexception.
                    {
                        File.SetAttributes(XmlHandler.XmlPath, File.GetAttributes(XmlHandler.XmlPath) & ~FileAttributes.ReadOnly); //So make it not readonly.
                        //Since the application must be run as admin in order to set attributes, I check for that.
                    }
                    try
                    {
                        File.Delete(XmlHandler.XmlPath);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        const string errText = "An error occurred whilst attempting to delete the corrupt config file. ";
                        if (!IsAdministrator()) //If the user isn't an administrator, then the file might be set to readonly.
                        {
                            dialogResult = "You are not running as administrator, so it's possible I do not have permission to access the file. Please re-run the tool as admin.";
                            MessageBox.Show(errText + dialogResult);
                            Application.Exit(); //Exit the tool so the user can re-run as admin. Really not much else I can do.
                        }
                    }
                }
                SaveSettings(settings, 2); //Try to generate a new config. Since I am calling from loadsettings, pass 2 to the context arg.
            }
            else
            {
                string dialogResult;
                try
                {
                    settings.AutoInject = loadedSettings.AutoInject;
                    settings.CloseAfterInjection = loadedSettings.CloseAfterInjection;
                    settings.Dll = loadedSettings.Dll;
                    settings.Process = loadedSettings.Process;
                    settings.SaveDll = loadedSettings.SaveDll;
                    settings.SaveProcessName = loadedSettings.SaveProcessName;
                    settings.SilentStart = loadedSettings.SilentStart;
                    settings.AutoCloseWarning = loadedSettings.AutoCloseWarning;
                    if (settings.SilentStart == 0)
                    {
                        dialogResult = "Successfully loaded the XML file.";
                        MessageBox.Show(dialogResult);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentOutOfRangeException)
                    {
                        dialogResult = "An error occurred whilst loading the settings file: One or more values were not set correctly. Did you manually edit the file? These settings have been set to their defaults.";
                    }
                    else
                    {
                        dialogResult = "An error occurred whilst loading the settings file: Unspecified error. Possible malformation of config file. Settings that failed to load have been set back to their defaults.";
                    }
                    MessageBox.Show(dialogResult);
                }
            }
        }

        /*
            If the context passed is 1, then the caller was the on_exit function, and I will ignore the exceptions to let it close gracefully.
            If the context passed is 2, then the caller was the load settings function, and I will tell the user an error occured generating a new config.
        */
        public static void SaveSettings(SettingsHandler settings, int context)
        { //For saving settings to the XML file.
            int saveSettings = XmlHandler.Serialize_Settings(settings); //Return 1 for success, 0 on unauthorized access exception.
            if (context == 1 && saveSettings != 1)
            {
                if (settings.SaveDll == 0)
                {
                    settings.Dll = "Not set";
                }
                if (settings.SaveProcessName == 0)
                {
                    settings.Process = "Not set";
                }
                XmlHandler.Serialize_Settings(settings); //If an exception occurs, ignore it and exit.
            }
            else if (context == 2 && saveSettings != 1)
            {
                const string dialogResult = "An access violation occurred whilst generating a new configuration file. Are you running as admin?";
                MessageBox.Show(dialogResult);
            }
        }

        public static void Inject(SettingsHandler settings, Timer autoShutdownTimer, int shutdownCountdownVar, int caller)
        {
            int returnValue = DLLInjector.InjectDll(settings.Process, settings.Dll);
            string dialogResult;

            if (returnValue != 0)
            {
                if (returnValue == 5)
                {
                    dialogResult = "Failed to inject the process: An access violation occurred. Are you running as admin?";
                }
                if (returnValue == 6)
                {
                    dialogResult = "Failed to inject the process: Handle invalid.";
                }
                //idk those are the two most likely ones to happen
                else
                {
                    dialogResult = "Failed to inject the process. Error code: " + returnValue.ToString();
                }
                MessageBox.Show(dialogResult);
            }
            else
            {
                if (settings.CloseAfterInjection == 1 && caller == 1)
                {
                    autoShutdownTimer.Enabled = true; //After 3 seconds, the timer's tick() gets called, causing Application.Exit() to be called.
                    if (settings.AutoCloseWarning == 1)
                    {
                        dialogResult = "Successfully injected the process. Close after injection is enabled, so I will close after 5 seconds.";
                        const string dialogTitle = "Auto-Close Enabled";
                        var result = MessageBox.Show(dialogResult, dialogTitle, MessageBoxButtons.OKCancel);
                        if (result == DialogResult.Cancel) //If the user presses cancel, then... You know, cancel the thing.
                        {
                            autoShutdownTimer.Enabled = false;
                        }
                    }
                }
                else
                {
                    dialogResult = "Successfully injected the process.";
                    MessageBox.Show(dialogResult);
                }
            }
        }
        public static void Exit(int context, SettingsHandler settings)
        {
            if (settings.SaveDll == 0)
            {
                settings.Dll = "Not set";
            }
            if (settings.SaveProcessName == 0)
            {
                settings.Process = "Not set";
            }
            SaveSettings(settings, context);
            Application.Exit();
        }
    }
}
