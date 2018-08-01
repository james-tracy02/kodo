using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Kodo
{
    public class Profiles
    {
        public static StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

        public static async Task CreateAsync(Profile profile)
        {
            StorageFile file = await storageFolder.CreateFileAsync(profile.Username + ".txt", CreationCollisionOption.FailIfExists);
            await FileIO.WriteLinesAsync(file, profile.Lines());
            return;
        }

        public static async Task<Profile> GetAsync(string username)
        {
            StorageFile file = await storageFolder.GetFileAsync(username + ".txt");
            var profile = await FileIO.ReadLinesAsync(file);
            return new Profile(profile);
        }

        public static async Task DeleteAllAsync()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            var files = await storageFolder.GetFilesAsync();
            files.ToList().ForEach(async x => await x.DeleteAsync());
            return;
        }

        public static async Task UpdateAsync(Profile profile)
        {
            StorageFile file = await storageFolder.GetFileAsync(profile.Username + ".txt");
            await FileIO.WriteLinesAsync(file, profile.Lines());
            return;
        }

        public static async Task LoginAsync(Login login)
        {
            StorageFile file = await storageFolder.CreateFileAsync("login.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteLinesAsync(file, login.Lines());
            return;
        }

        public static async Task<Login> GetLoginAsync()
        {
            StorageFile file = await storageFolder.GetFileAsync("login.txt");
            var login = await FileIO.ReadLinesAsync(file);
            return new Login(login);
        }
    }
}
