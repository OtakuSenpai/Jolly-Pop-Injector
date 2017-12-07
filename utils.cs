using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace Jolly_Pop_Injector {
    public static class utils {
        public static void HandleXML(SettingsHandler settings) { //For loading settings from the XML file.
            int loadxml = XMLHandler.LoadSettingsFromXML(settings);
            if (loadxml == 1) {
                MessageBox.Show("Successfully found & Read XML.");
            } else if (loadxml == 2 || loadxml == 3) {
                MessageBox.Show("An XML file was found, but an error occurred whilst reading it. It is possible one or more settings were not set. They have been set to default.");
            } else {
                MessageBox.Show("Didn't find an XML file. Will now generate one with default values...");
                XMLHandler.GenerateXML(settings);
                XMLHandler.LoadSettingsFromXML(settings);
            }
        }

        public static bool IsAdministrator() { //Detects if the user is admin or not (dur)
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
