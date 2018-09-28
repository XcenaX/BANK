using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal;
using PayPal.Api;
using static System.Console;
using BankLibrary;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Bank<BankLibrary.Account> bank = new Bank<BankLibrary.Account>("ЮнитБанк");
            bool alive = true;
            while (alive)
            {
                Console.WriteLine("1. Открыть счет \t 2. Вывести средства  \t 3. Добавить на счет");
                Console.WriteLine("4. Закрыть счет \t 5. Пропустить день \t 6. Выйти из программы");
                Console.WriteLine("Введите номер пункта:");
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            OpenAccount(bank);
                            break;
                        case 2:
                            Withdraw(bank);
                            break;
                        case 3:
                            Put(bank);
                            break;
                        case 4:
                            CloseAccount(bank);
                            break;
                        case 5:
                            Clear();
                            
                            break;
                        case 6:
                            alive = false;
                            continue;
                    }
                    bank.CalculatePercentage();
                }
                catch (Exception ex)
                {
                    Clear();
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void OpenAccount(Bank<BankLibrary.Account> bank)
        {
            Clear();
            Console.WriteLine("Укажите сумму для создания счета:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Clear();
            Console.WriteLine("Выберите тип счета: 1. До востребования 2. Депозит");
            AccountType accountType;

            int type = Convert.ToInt32(Console.ReadLine());

            if (type == 2)
                accountType = AccountType.Deposit;
            else
                accountType = AccountType.Ordinary;

            bank.Open(accountType,
                sum,
                AddSumHandler,  // обработчик добавления средств на счет
                WithdrawSumHandler, // обработчик вывода средств
                (o, e) => Console.WriteLine(e.Message), // обработчик начислений процентов в виде лямбда-выражения
                CloseAccountHandler, // обработчик закрытия счета
                OpenAccountHandler); // обработчик открытия счета
        }

        private static void Withdraw(Bank<BankLibrary.Account> bank)
        {
            Clear();
            Console.WriteLine("Укажите сумму для вывода со счета:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Clear();
            Console.WriteLine("Введите id счета:");
            int id = Convert.ToInt32(Console.ReadLine());

            bank.Withdraw(sum, id);
        }

        private static void Put(Bank<BankLibrary.Account> bank)
        {
            Clear();
            Console.WriteLine("Укажите сумму, чтобы положить на счет:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Clear();
            Console.WriteLine("Введите Id счета:");
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Put(sum, id);
        }

        private static void CloseAccount(Bank<BankLibrary.Account> bank)
        {
            Clear();
            Console.WriteLine("Введите id счета, который надо закрыть:");
            int id = Convert.ToInt32(Console.ReadLine());

            bank.Close(id);
        }
        // обработчики событий класса Account
        // обработчик открытия счета
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик добавления денег на счет
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик вывода средств
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Sum > 0)
            {
                Clear();
                Console.WriteLine("Идем тратить деньги");
            }
        }
        // обработчик закрытия счета
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}