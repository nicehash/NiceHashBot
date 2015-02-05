using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace NiceHashBot
{
    public class SettingsContainer
    {
        public int APIID;
        public string APIKey;
        public string TwoFactorSecret;

        public static SettingsContainer Settings;

        public SettingsContainer()
        {
            APIID = 0;
            APIKey = "";
            TwoFactorSecret = "";
        }

        public static void Initialize()
        {
            string TextData = null;
            try
            {
                TextData = File.ReadAllText("settings.json");
            }
            catch { }

            if (TextData != null)
            {
                Settings = JsonConvert.DeserializeObject<SettingsContainer>(TextData);
            }
            else
            {
                Settings = new SettingsContainer();
            }
        }


        public static void Commit()
        {
            string TextData = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText("settings.json", TextData);
        }
    }
}
