using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;

namespace Jolly_Pop_Injector
{
    public static class utils
    {
        public static bool IsAdministrator()
        { //Detects if the user is admin or not (dur)
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void LoadSettings(SettingsHandler settings, int context) //Pass the context so if I need to call SerializeSettings, I will have something to pass it.
        { //For loading settings from the XML file.
            SettingsHandler loaded_settings = XMLHandler.DeSerialize_Settings();
            if (loaded_settings == null)
            {
                if (!XMLHandler.XMLExists())
                {
                    MessageBox.Show("I did not find an XML config file. A new one will be generated with default values.");
                }
                else
                {
                    MessageBox.Show("An XML config file was found, but I failed to load it properly. It is possible it is damaged. A new one will be generated.");
                    FileInfo fi = new FileInfo(XMLHandler.XMLPath);
                    if (fi.IsReadOnly && IsAdministrator()) //If the file is readonly for some reason, that will cause an unauthorizedaccessexception.
                    {
                        File.SetAttributes(XMLHandler.XMLPath, File.GetAttributes(XMLHandler.XMLPath) & ~FileAttributes.ReadOnly); //So make it not readonly.
                        //Since the application must be run as admin in order to set attributes, I check for that.
                    }
                    try
                    {
                        File.Delete(XMLHandler.XMLPath);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        string err_text = "An error occurred whilst attempting to delete the corrupt config file. ";
                        if (!IsAdministrator()) //If the user isn't an administrator, then the file might be set to readonly.
                        {
                            MessageBox.Show(err_text + "You are not running as administrator, so it's possible I do not have permission to access the file. Please re-run the tool as admin.");
                            Application.Exit(); //Exit the tool so the user can re-run as admin. Really not much else I can do.
                        }
                    }
                }
                SaveSettings(settings, 2); //Try to generate a new config. Since I am calling from loadsettings, pass 2 to the context arg.
            }
            else
            {
                settings.AutoInject = loaded_settings.AutoInject;
                settings.CloseAfterInjection = loaded_settings.CloseAfterInjection;
                settings.DLL = loaded_settings.DLL;
                settings.Process = loaded_settings.Process;
                settings.SaveDLLlocation = loaded_settings.SaveDLLlocation;
                settings.SaveProcessName = loaded_settings.SaveProcessName;
                MessageBox.Show("Successfully loaded the XML file.");
            }
        }

        /*
            If the context passed is 1, then the caller was the on_exit function, and I will ignore the exceptions to let it close gracefully.
            If the context passed is 2, then the caller was the load settings function, and I will tell the user an error occured generating a new config.
        */
        public static void SaveSettings(SettingsHandler settings, int context)
        { //For saving settings to the XML file.
            int save_settings = XMLHandler.Serialize_Settings(settings); //Return 1 for success, 0 on unauthorized access exception.
            if (context == 1 && save_settings != 1)
            {
                if (settings.SaveDLLlocation == 1)
                {
                    settings.DLL = "Not set";
                }
                if (settings.SaveProcessName == 1)
                {
                    settings.Process = "Not set";
                }
                save_settings = XMLHandler.Serialize_Settings(settings); //If an exception occurs, ignore it and exit.
            }
            else if (context == 2 && save_settings != 1)
            {
                MessageBox.Show("An access violation occurred whilst generating a new configuration file. Are you running as admin?");
            }
        }

        public static void Inject(SettingsHandler settings, Timer AutoShutdownTimer)
        {
            int return_value = DLLInjector.InjectDLL(settings.Process, settings.DLL);
            if (return_value != 1)
            {
                if (return_value == 5)
                {
                    MessageBox.Show("Failed to inject the process: An access violation occurred. Are you running as admin?");
                }
                if (return_value == 6)
                {
                    MessageBox.Show("Failed to inject the process: The handle is invalid. ");
                }
                //idk those are the two most likely ones to happen
                else
                {
                    MessageBox.Show("Failed to inject the process. Error code: " + return_value.ToString()); // :<
                }
            }
            else
            {
                if (settings.CloseAfterInjection == 1)
                {
                    AutoShutdownTimer.Enabled = true; //After 3 seconds, the timer's tick() gets called, causing Application.Exit() to be called.
                    var result = MessageBox.Show("Successfully injected the process. Close after injection is enabled, so I will close in 3 seconds.", "Auto-Close Enabled", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel) //If the user presses cancel, then... You know, cancel the thing.
                    {
                        AutoShutdownTimer.Enabled = false;
                    }
                }
                MessageBox.Show("Successfully injected the process.");
            }
        }
    }
}
