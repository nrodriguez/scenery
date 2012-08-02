using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamWebAPI;

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
    }
}