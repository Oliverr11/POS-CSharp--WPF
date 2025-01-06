using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.Model
{
    public class Admin
    {
        public string userName {  get; set; }
        public string password { get; set; }
        public Admin()
        {

        }
        public Admin(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
