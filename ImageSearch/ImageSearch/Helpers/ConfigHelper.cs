using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace ImageSearch.Helpers
{
    internal class ConfigHelper
    {
        private const string ConfigFilePath = "config.json";
        public static AppConfig Config;

        private ConfigHelper()
        {
        }

        public static void Init()
        {
            if (!File.Exists(ConfigFilePath))
            {
                // 檔案不存在時，創建預設設定
                Config = new AppConfig();
                Save();
            }

            string json = File.ReadAllText(ConfigFilePath);
            Config = JsonSerializer.Deserialize<AppConfig>(json);
        }

        private static void Save()
        {
            //WriteIndented:開啟換行縮排, IgnoreReadOnlyProperties : 只讀屬性
            string json = JsonSerializer.Serialize(Config, new JsonSerializerOptions { WriteIndented = true, IgnoreReadOnlyProperties = true });
            File.WriteAllText(ConfigFilePath, json);
        }

        internal class AppConfig
        {
            [JsonInclude]
            private string Theme = "System";
            [JsonInclude]
            private bool CheckRect = true;
            [JsonInclude]
            private bool ExpandSearch = false;

            //GET SET
            public string GetTheme => this.Theme;
            public void SetTheme(string _theme)
            {
                if (this.Theme != _theme)
                {
                    this.Theme = _theme;
                    Save();
                }
            }

            public bool GetCheckRect => this.CheckRect;
            public void SetCheckRect(bool _checkRect)
            {
                if (this.CheckRect != _checkRect)
                {
                    this.CheckRect = _checkRect;
                    Save();
                }
            }

            public bool GetExpandSearch => this.ExpandSearch;
            public void SetExpandSearch(bool _expandSearch)
            {
                if (this.ExpandSearch != _expandSearch)
                {
                    this.ExpandSearch = _expandSearch;
                    Save();
                }
            }
        }
    }
}
