using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using SteamWebAPI;
using RegistryUtils;

namespace Scenery.Games
{
    sealed class Dota2 : Game
    {
        public override string Name { get; set; }
        public override string ApplicationName { get; set; }

        RegistryMonitor monitor = new RegistryMonitor(RegistryHive.CurrentUser, "Software/Valve/Steam/LastGameNameUsed");

        public Dota2()
            : base()
        {
            this.Name = "Dota 2";
            this.ApplicationName = "dota";
        }

        public override bool IsInGame()
        {
            //monitor.RegChanged += new EventHandler(bool OnRegChanged);
            //monitor.Start();
            //return monitor.RegChanged;
            return true;
        }

        private bool OnRegChanged(object sender, EventArgs e)
        {
            //monitor.Stop();
            return true;
        }
    }
}