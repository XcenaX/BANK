using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bankomat
{
    public class Bank
    {

        public List<Client> clients { get; set; }

        public Bank()
        {
            clients = new List<Client>();
        }

        public void AddAccount(Client client)
        {
            clients.Add(client);
        }

        public bool CheckSameAccount(string data)
        {
            for(int i = 0; i < clients.Count; i++)
            {
                if (data == clients[i].account.IIN) return true;
                else if (data == clients[i].account.Phone) return true;
            }
            return false;
        }



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
