using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Kodo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecretsView : Page
    {

        public SecretsView()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(900, 580);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            this.LoadSecrets();
        }

        private void AddSecret_Click(object sender, RoutedEventArgs e)
        {
            AddSecret(this.addSecretNameBox.Text, this.addSecretSecretBox.Password);
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }

        private async void LoadSecrets()
        {
            var login = await Profiles.GetLoginAsync();
            var profile = await Profiles.GetAsync(login.Username);
            var secrets = profile.Secrets;

            secrets.ToList().ForEach(secret => secret.Password = Crypto.Decrypt(login.Password, secret.Password));
            this.secretsList.ItemsSource = secrets;
            return;
        }

        private async void AddSecret(string name, string secret)
        {
            var login = await Profiles.GetLoginAsync();
            var profile = await Profiles.GetAsync(login.Username);
            var secrets = profile.Secrets;

            secrets.Add(new Secret(name, Crypto.Encrypt(login.Password, secret)));
            await Profiles.UpdateAsync(profile);

            LoadSecrets();
            return;
        }

        private void GeneratePassword()
        {
            var bytes = Crypto.GenerateBytes(16);
            var result = Convert.ToBase64String(bytes);
            WriteResult(result);
            return;
        }

        private void WriteResult(string result)
        {
            this.resultBox.Text = result;
            return;
        }
    }
}
