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
                if (!String.IsNullOrEmpty(code))
                {
                    status = api.Authenticate(name, pw, code);
                }
                else
                {
                    status = api.Authenticate(name, pw);
                }

                if (status == SteamAPISession.LoginStatus.SteamGuard)
                {
                    response.Text = "Steamguard is setup. Please check your email and enter the Steamguard code. ";
                    steamguard.Visibility = Visibility.Visible;
                    steamguard_label.Visibility = Visibility.Visible;
                }

                if (status == SteamAPISession.LoginStatus.LoginSuccessful)
                {
                    List<SteamAPISession.Friend> friends = api.GetFriends();
                    int blockedFriends = friends.Count(f => f.blocked == true);
                    response.Text = "You have " + (friends.Count - blockedFriends) + " friends and " + blockedFriends + " fiends!";

                    this.Hide();
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
