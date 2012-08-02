using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace Scenery.Games
{
    public class Game
    {
        public virtual string Name { get; set; }

        public virtual string ApplicationName { get; set; }

        public Game()
        {
            //Name = "Game";
            //ApplicationName = "Game.exe";
        }

        public string CheckGameStatus()
        {
            return IsProcessOpen(this.ApplicationName) ? "Running" : "Not Running";
        }

        public virtual bool IsInGame()
        {
            return true;
        }

        private bool IsProcessOpen(string appName)
        {
            Process[] pname = Process.GetProcessesByName(appName);
            return pname.Length != 0;
        }
    }
}