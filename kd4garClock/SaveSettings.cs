using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace kd4garClock
{
    class SaveSettings
    {
        Windows.Storage.ApplicationDataContainer localSettings;
        Windows.Storage.StorageFolder localFolder;

        public bool Show24Hour
        {
            get
            {
               
                if (localSettings.Values["twentyfourhour"] == null)
                {
                    localSettings.Values["twentyfourhour"] = false;
                }
                return bool.Parse(localSettings.Values["twentyfourhour"].ToString());

            }

            set
            {
                localSettings.Values["twentyfourhour"] = value;
            }
        }





        //Constructor...

        public SaveSettings()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        }
    }
}
