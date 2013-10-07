using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using SteamWebAPI;
using Microsoft.Win32;
using System.Windows;

[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, All = "HKEY_CURRENT_USER")]

namespace Scenery.Games
{
    sealed class XSplit : Game
    {
        public override string Name { get; set; }
        public override string ApplicationName { get; set; }

        public XSplit()
            : base()
        {
            this.Name = "XSplit";
            this.ApplicationName = "XSplit.Core";
        }

        public string GetCurrentScene()
        {
            //Logic to tie into xsplit and the scenes is borrowed from HellGreen
            // http://www.xsplit.com/forum/viewtopic.php?f=18&t=4755
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\SplitMediaLabs\\XSplitBroadcaster", false);
            string placements = (string) regKey.GetValue("Placements", "");
            regKey.Close();

            int sceneNumber = int.Parse(placements.Substring(20, 2));
            //return SceneGroup(9 + sceneNumber).mainWindowTitle;
            return "";
        }

        public void GetAllScenes()
        {
            if(base.CheckGameStatus() == "Running")
            {
                //The ClassName or the first argument in FindWindow was acquired through Visual Studios Spy++
                IntPtr handle_id = UnsafeNativeMethods.FindWindow("WindowsForms10.Window.8.app.0.2004eee", "XSplit Broadcaster");
                StringBuilder stringBuilder = new StringBuilder(256);
                UnsafeNativeMethods.GetWindowText(handle_id, stringBuilder, stringBuilder.Capacity);
                //ManagedWinapi.ClipboardNotifier
            }
        }

        //Finding window
        internal static class UnsafeNativeMethods
        {
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            internal static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        }
        
    }

}