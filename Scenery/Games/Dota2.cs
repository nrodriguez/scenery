﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using SteamWebAPI;
using RegistryUtils;
using Read64bitRegistryFrom32bitApp;
using System.Net.Sockets;
using System.Net;

namespace Scenery.Games
{
    sealed class Dota2 : Game
    {
        public override string Name { get; set; }
        public override string ApplicationName { get; set; }
        public override bool IsInGame { get; set; }
        RegistryMonitor monitor = new RegistryMonitor(RegistryHive.CurrentUser, "Software\\Valve\\Steam\\LastGameNameUsed");

        public Dota2()
            : base()
        {
            this.Name = "Dota 2";
            this.ApplicationName = "dota";
        }

        public override void StartInGameCheck()
        {
            RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            localKey = localKey.OpenSubKey(@"SOFTWARE\Software\Valve\Steam");

            NetReceiver receiver = new NetReceiver(27005);
            receiver.UDPListen();

            monitor.RegChanged += new EventHandler(OnRegChanged);
            monitor.Start();
        }

        public override void EndInGameCheck()
        {
            monitor.Stop();
            IsInGame = false;
        }

        public void OnRegChanged(object sender, EventArgs e)
        {
            IsInGame = true;
            var vca = new ValueChangedArgs();
            vca.OnValueChanged(new ValueChangedArgs { OldValue = 1, NewValue = 2 });
        }

    }
}