using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageSearch.Helpers
{
    internal static class Utility
    {
        public const string dbPath = "Database_";
        public const string tempPath = "_Temp";
        public const string searchPath = "Search";
        public const string releasePath = "Release";

        public static bool IsBackdropSupported()
        {
            var os = Environment.OSVersion;
            var version = os.Version;

            return version.Major >= 10 && version.Build >= 22621;
        }

        public static bool IsBackdropDisabled()
        {
            var appContextBackdropData = AppContext.GetData("Switch.System.Windows.Appearance.DisableFluentThemeWindowBackdrop");
            bool disableFluentThemeWindowBackdrop = false;

            if (appContextBackdropData != null)
            {
                disableFluentThemeWindowBackdrop = bool.Parse(Convert.ToString(appContextBackdropData));
            }

            return disableFluentThemeWindowBackdrop;
        }

        #region 禁用關閉按鈕
        public const UInt32 SC_CLOSE = 0x0000F060;
        public const UInt32 MF_BYCOMMAND = 0x00000000;

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);
        [DllImport("USER32.DLL ", CharSet = CharSet.Unicode)]
        public static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);
        #endregion
    }
}
