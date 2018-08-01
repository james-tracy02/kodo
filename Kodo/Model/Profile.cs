using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodo
{
    public class Profile
    {
        public Profile(IList<string> lines)
        {
            this.Username = lines[0];
            this.Password = lines[1];
            this.Email = lines[2];
            this.Secrets = new List<Secret>();

            for(var i = 3; i < lines.Count; i+=2)
            {
                this.Secrets.Add(new Secret(lines[i], lines[i + 1]));
            }
        }

        public Profile(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Secrets = new List<Secret>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public IList<Secret> Secrets { get; }

        public IList<string> Lines()
        {
            var lines = new List<string>();
            lines.Add(this.Username);
            lines.Add(this.Password);
            lines.Add(this.Email);

            foreach(var secret in this.Secrets)
            {
                lines.Add(secret.Name);
                lines.Add(secret.Password);
            }

            return lines;
        }
    }
}
