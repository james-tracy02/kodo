using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodo
{
    public class Login
    {
        public Login(IList<string> lines)
        {
            this.Username = lines[0];
            this.Password = lines[1];
        }

        public Login(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; }

        public string Password { get; }

        public IList<string> Lines()
        {
            var lines = new List<string>();
            lines.Add(this.Username);
            lines.Add(this.Password);
            return lines;
        }
    }
}
