using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BankLibrary
{
    public class DemandAccount : Account
    {
        public DemandAccount(decimal sum, int percentage) : base(sum, percentage)
        {
        }

        protected internal override void Open()
        {
            Clear();
            base.OnOpened(new AccountEventArgs("Открыт новый счет до востребования! Id счета: " + this.id, this.sum));
        }
    }
}
