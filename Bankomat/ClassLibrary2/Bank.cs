using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountName;
using ClientName;

namespace BankName
{
    public class Bank
    {
        public string Print(Client client, Account account)
        {
            return
                "Клиент: " +client.FirstName + client.FirstName +
                "\nНомер счета: " + account.Id +
                "\nСумма на счете: " + account.Amount;
        }
        public void ReplenishAmount(Account account, int deposit)
        {
            account.Amount+= deposit;
            Console.WriteLine("Счет пополнен");
            Console.ReadKey();
        }
        public void PullAmount(Account account, int deposit)
        {
            if (account.Amount >= deposit)
            {
                account.Amount -= deposit;
                Console.WriteLine("Сумма со счета снята");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("На счете недостаточно средств");
                Console.ReadKey();
            }
        }
    }
}
