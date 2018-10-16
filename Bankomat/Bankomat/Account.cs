using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Account
    {
        public int Id { get; set; }
        public int Password { get; set; } 
        public double Amount { get; set; } 
        public string Phone { get; set; }
        public string IIN{ get; set; }
        public DateTime DateOfCreate { get; private set; }

        public Account()
        {
            Id = 0;
            Password = 0;
            Amount = 0;
            Phone = "";
            IIN = "";
            DateOfCreate = DateTime.Now;
        }
    }
}
