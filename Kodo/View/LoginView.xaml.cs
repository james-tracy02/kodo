using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Kodo
{
    public sealed partial class LoginView : Page
    {
        public LoginView()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(900, 580);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(900, 580));
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            await Login(this.usernameBox.Text, this.passwordBox.Password);
            return;
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateAccountView));
            return;
        }

        private async Task Login(string username, string password)
        {

            Profile profile;
            string targetPassword;

            try
            {
                profile = await Profiles.GetAsync(username);
                targetPassword = Crypto.Decrypt(password, profile.Password);

            }
            catch (Exception)
            {
                ShowError("Username and Password combination incorrect. Please try again.");
                ClearLogin();
                return;
            }

            if(!password.Equals(targetPassword))
            {
                ShowError("Username and Password combination incorrect. Please try again.");
                ClearLogin();
                return;
            }

            var login = new Login(username, password);
            await Profiles.LoginAsync(login);
            ShowSuccess("Login successful.");

            this.Frame.Navigate(typeof(SecretsView));
            return;
        }

        private void ClearLogin()
        {
            this.usernameBox.Text = "";
            this.passwordBox.Password = "";
            return;
        }

        private void ShowError(string msg)
        {
            this.successBox.Visibility = Visibility.Collapsed;
            this.errorBox.Visibility = Visibility.Visible;
            this.errorText.Text = msg;
            return;
        }

        private void ShowSuccess(string msg)
        {
            this.errorBox.Visibility = Visibility.Collapsed;
            this.successBox.Visibility = Visibility.Visible;
            this.successText.Text = msg;
            return;
        }
    }
}
