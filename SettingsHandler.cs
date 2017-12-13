using System;
using System.Runtime.Serialization;

namespace Jolly_Pop_Injector
{
    public class SettingsHandler
    {
        [DataMember] private int _autoInject;
        [DataMember] private int _closeAfterInjection;
        [DataMember] private int _autoCloseWarning;
        [DataMember] private int _saveProcessName = 1;
        [DataMember] private int _saveDll = 1;
        [DataMember] private int _silentStart;
        [DataMember] private string _process = "Not set";
        [DataMember] private string _dll = "Not set";


        public int AutoInject
        {
            get { return _autoInject; }

            set
            {
                if (value == 0 || value == 1)
                {
                    _autoInject = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int CloseAfterInjection
        {
            get { return _closeAfterInjection; }
            set
            {
                if (value == 0 || value == 1)
                {
                    _closeAfterInjection = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int AutoCloseWarning
        {
            get { return _autoCloseWarning; }
            set
            {
                if (value == 1 || value == 0)
                {
                    _autoCloseWarning = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int SaveProcessName
        {
            get { return _saveProcessName; }
            set
            {
                if (value == 1 || value == 0)
                {
                    _saveProcessName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int SaveDll
        {
            get { return _saveDll; }
            set
            {
                if (value == 1 || value == 0)
                {
                    _saveDll = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int SilentStart
        {
            get { return _silentStart; }
            set
            {
                if (value == 1 || value == 0)
                {
                    _silentStart = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Process
        {
            get { return _process; }
            set { _process = value; }
        }

        public string Dll
        {
            get { return _dll; }
            set { _dll = value; }
        }
    }
}
