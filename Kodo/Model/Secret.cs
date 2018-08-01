using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodo
{
    public class Secret
    {
        public Secret(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Display
        {
            get
            {
                return this.Name + ": " + this.Password;
            }
        }
    }
}
