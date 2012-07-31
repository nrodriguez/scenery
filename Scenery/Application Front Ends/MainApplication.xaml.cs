using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Scenery.Games;

namespace Scenery
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainApplication : Window
    {
        //We take in an api in case we're gonna use steam for Dota 2
        public MainApplication(string GameName, SteamWebAPI.SteamAPISession api = null)
        {
            InitializeComponent();
            Game game = GetGame(GameName);
            
        }

        private Game GetGame(string GameName)
        {
            GameStatusLabel.Content = String.IsNullOrEmpty(GameName) ? "Game" : GameStatusLabel.Content = GameName;
            
            switch (GameName)
            {
                case "Dota 2":
                    return new Dota2();
                default:
                    return new Game();
            }
        }

        private void RunApplication_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
