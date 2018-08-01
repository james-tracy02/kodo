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
    public sealed partial class CreateAccountView : Page
    {
        public CreateAccountView()
        {
            this.InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateAccountView));
            return;
        }

        private async void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            await CreateProfile(this.usernameBox.Text, this.passwordBox.Password, this.confirmPasswordBox.Password, this.emailBox.Text);
            return;
        }
        private void ClearAll()
        {
            this.usernameBox.Text = "";
            this.emailBox.Text = "";
            this.passwordBox.Password = "";
            this.confirmPasswordBox.Password = "";
            return;
        }

        private void ClearPasswords()
        {
            this.passwordBox.Password = "";
            this.confirmPasswordBox.Password = "";
            return;
        }

        private async Task CreateProfile(string username, string password, string confirmPassword, string email) {
            if(String.IsNullOrEmpty(username)
                || String.IsNullOrEmpty(password)
                || String.IsNullOrEmpty(email))
            {
                ShowError("All fields required.");
                return;
            }

            if(!password.Equals(confirmPassword))
            {
                ShowError("Passwords do not match.");
                ClearPasswords();
                return;
            }

            try
            {
                await Profiles.CreateAsync(new Profile(username, Crypto.Encrypt(password, password), email));
            }
            catch(Exception)
            {

                ShowError("Profile with that name already exists.");
                ClearAll();
            }
            ShowSuccess("Profile created.");
            this.Frame.Navigate(typeof(LoginView));
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
