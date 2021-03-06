﻿using System;
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
using SteamWebAPI;

namespace Scenery
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SteamLoginWindow : Window
    {
        public SteamLoginWindow()
        {
            InitializeComponent();
        }

        private void AuthClick(object sender, RoutedEventArgs e)
        {
            String name = username.Text;
            String pw = password.Password;
            String code = steamguard.Text;
            SteamAPISession api = new SteamAPISession();
            SteamAPISession.LoginStatus status;

            try
            {   
                

                //Lets see if they gave the code already or not
                if (String.IsNullOrEmpty(code))
                {
                    status = api.Authenticate(name, pw);
                }
                else
                {
                    status = api.Authenticate(name, pw, code);
                }

                //We realized they have a steamguard id and we need that to continue authenticating
                if (status == SteamAPISession.LoginStatus.SteamGuard)
                {
                    response.Text = "Steamguard is setup. Please check your email and enter the Steamguard code. ";
                    steamguard.Visibility = Visibility.Visible;
                    steamguard_label.Visibility = Visibility.Visible;
                }

                //The login was successful. Pass the reference to api along to the main app
                if (status == SteamAPISession.LoginStatus.LoginSuccessful)
                {
                    //List<SteamAPISession.Friend> friends = api.GetFriends();

                    this.Hide();
                    string game = "Dota 2";
                    MainApplication app = new MainApplication(game, api);
                    app.Show();

                }
                else
                {
                    response.Text += "Failed to log in!";
                }
            }
            catch (Exception)
            {
                response.Text = "Failed to log in!";
            }

        }
    }
}
