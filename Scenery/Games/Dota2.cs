using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamWebAPI;

namespace Scenery.Games
{
    class Dota2 : Game
    {
        public new string Name { get; set; }

        public Dota2() : base()
        {
            this.Name = "Dota 2";
        }

        public new bool CheckGameStatus()
        {
            return true;
        }
    }
}
