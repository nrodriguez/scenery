using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scenery.Games
{
    public class Game
    {
        protected string Name;
        
        public string name
        {
            get { return this.Name; }
            set { Name = value; }
        }

        public Game()
        {
            Name = "Game";
        }

        public Game(string name)
        {
            this.Name = name;
        }

        public bool CheckGameStatus()
        {
            return true;
        }

    }
}
