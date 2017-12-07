using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace Jolly_Pop_Injector {
    public class XMLHandler {
        private static string XMLPath = Application.StartupPath + "/JPI.xml";

        private static bool XMLExists() { //Check if the XML configuration file exists.
            if (File.Exists(XMLPath)) {
                return true;
            } else {
                return false;
            }
        }

        public static void GenerateXML(SettingsHandler settings) { //Used for generating a new XML file with hardcoded default values.
            try {
                XmlWriter xmlWriter = XmlWriter.Create("JPI.xml");

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("JPI");

                xmlWriter.WriteStartElement("JPISettings");
                xmlWriter.WriteAttributeString("AutoInject", "1");
                xmlWriter.WriteAttributeString("CloseAfterInjection", "1");
                xmlWriter.WriteAttributeString("SaveProcessName", "1");
                xmlWriter.WriteAttributeString("SaveDLLlocation", "1");
                xmlWriter.WriteAttributeString("DLL", "not set");
                xmlWriter.WriteAttributeString("Process", "not set");

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            } catch (System.UnauthorizedAccessException) {
                MessageBox.Show("Error! I can not create an XML file at this location. You do not have access. Please re-run as Admin. I will continue without writing a config.");
            }
        }

        public static void WriteSettingsToXML(SettingsHandler settings) { //Called when program exits. Push current settings to the XML file.
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load(XMLPath);
            } catch (XmlException) { //Root element missing
                XmlElement elem = doc.CreateElement("JPI");
                doc.AppendChild(elem);
            }
            //These are to determine if the XML wrote everything correctly.
            bool AutoInjectWrote = true;
            bool CloseAfterInjectionWrote = true;
            bool SaveProcessNameWrote = true;
            bool SaveDllLocationWrote = true;
            bool ProcessWrote = true;
            bool DLLWrote = true;

            XmlNode root = doc.DocumentElement["JPISettings"];
            try {
                foreach (XmlAttribute c in root.Attributes) {
                    if (c.Name == "AutoInject") {
                        c.Value = settings.AutoInject.ToString();
                    } else {
                        AutoInjectWrote = false;
                    }
                    if (c.Name == "CloseAfterInjection") {
                        c.Value = settings.CloseAfterInjection.ToString();
                    } else {
                        CloseAfterInjectionWrote = false;
                    }
                    if (c.Name == "SaveProcessName") {
                        c.Value = settings.SaveProcessName.ToString();
                    } else {
                        SaveProcessNameWrote = false;
                    }
                    if (c.Name == "SaveDLLlocation") {
                        c.Value = settings.SaveDllLocation.ToString();
                    } else {
                        SaveDllLocationWrote = false;
                    }
                    if (c.Name == "Process") {
                        c.Value = settings.Process;
                    } else {
                        ProcessWrote = false;
                    }
                    if (c.Name == "DLL") {
                        c.Value = settings.DLL;
                    } else {
                        DLLWrote = false;
                    }
                }
            } catch (NullReferenceException) { //Occurs if JPISettings doesn't exist
                XmlElement JPISettings = doc.CreateElement("JPISettings");
                doc.DocumentElement.AppendChild(JPISettings);
                AutoInjectWrote = false;
                CloseAfterInjectionWrote = false;
                SaveProcessNameWrote = false;
                SaveDllLocationWrote = false;
                ProcessWrote = false;
                DLLWrote = false;
                root = doc.DocumentElement["JPISettings"]; //Reset root to JPISettings. it will be written to later.
            }
            //Anakin Memewalker: This is where the fun begins
            //If any of the attributes failed to write, then remake them and try again.
            if (!AutoInjectWrote) {
                XmlAttribute AutoInject = doc.CreateAttribute("AutoInject");
                AutoInject.Value = settings.AutoInject.ToString();
                root.Attributes.SetNamedItem(AutoInject);
            }
            if (!CloseAfterInjectionWrote) {
                XmlAttribute CloseAfterInjection = doc.CreateAttribute("CloseAfterInjection");
                CloseAfterInjection.Value = settings.CloseAfterInjection.ToString();
                root.Attributes.SetNamedItem(CloseAfterInjection);
            }
            if (!SaveProcessNameWrote) {
                XmlAttribute SaveProcessName = doc.CreateAttribute("SaveProcessName");
                SaveProcessName.Value = settings.SaveProcessName.ToString();
                root.Attributes.SetNamedItem(SaveProcessName);
            }
            if (!SaveDllLocationWrote) {
                XmlAttribute SaveDllLocation = doc.CreateAttribute("SaveDllLocation");
                SaveDllLocation.Value = settings.SaveDllLocation.ToString();
                root.Attributes.SetNamedItem(SaveDllLocation);
            }
            if (!ProcessWrote) {
                XmlAttribute Process = doc.CreateAttribute("Process");
                Process.Value = settings.Process.ToString();
                root.Attributes.SetNamedItem(Process);
            }
            if (!DLLWrote) {
                XmlAttribute DLL = doc.CreateAttribute("DLL");
                DLL.Value = settings.DLL.ToString();
                root.Attributes.SetNamedItem(DLL);
            }
            doc.Save(XMLPath);
        }
        /*
            Rob say Code Monkey very dilligent - but his output stink.
            His code not functional or elegant.
            What do code monkey think?
        */
        public static int LoadSettingsFromXML(SettingsHandler s) {
            bool err = false; //If an error occurs during the loading, set this to true and leave the setting to its default value.
            if (XMLExists()) {
                //Load and set values
                XmlReader xmlReader = XmlReader.Create(XMLPath);
                try {
                    while (xmlReader.Read()) {
                        if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "JPISettings")) {
                            if (xmlReader.HasAttributes) {
                                int AutoInject;
                                int CloseAfterInjection;
                                int SaveProcessName;
                                int SaveDllLocation;
                                string Process;
                                string DLL;
                                if (!int.TryParse(xmlReader.GetAttribute("AutoInject"), out AutoInject)) {
                                    err = true;
                                } else {
                                    s.AutoInject = AutoInject;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("CloseAfterInjection"), out CloseAfterInjection)) {
                                    err = true;
                                } else {
                                    s.CloseAfterInjection = CloseAfterInjection;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("SaveProcessName"), out SaveProcessName)) {
                                    err = true;
                                } else {
                                    s.SaveProcessName = SaveProcessName;
                                }
                                if (!int.TryParse(xmlReader.GetAttribute("SaveDllLocation"), out SaveDllLocation)) {
                                    err = true;
                                } else {
                                    s.SaveDllLocation = SaveDllLocation;
                                }
                                DLL = xmlReader.GetAttribute("DLL");
                                Process = xmlReader.GetAttribute("Process");
                                if (DLL != null) {
                                    s.DLL = DLL;
                                } else {
                                    err = true;
                                }
                                if (Process != null) {
                                    s.Process = Process;
                                } else {
                                    err = true;
                                }
                            }
                        }
                    }
                } catch (XmlException) {
                    return 2; //2 == Exception
                }
                if (err == true) {
                    return 3; //3 == One or more values not read properly; they are set to default values
                }
                return 1; //1 == Successfully read
            } else {
                return 0; //0 == didn't find an XML
            }
            //TODO: Make this class not shit.
        }
    }
}