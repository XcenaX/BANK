using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Bankomat
{
    class Program
    {
        const int ZERO = 0, ONE = 1, TWO = 2, THREE = 3, SEVEN = 7, EIGHT = 8, NINE = 9, TEN = 10,TWELWE=12, FOURTHYFIVE = 45;
        static void Main(string[] args)
        {
            int isPassword, deposit = ZERO;
            int key = ZERO;
            ConsoleKey button;
            bool isPars;

            string test = ReadLine();


            Bank bank = new Bank();

            Client client = new Client();

            

            bool check = false;

            while (!check)
            {
            Clear();
            WriteLine("Есть ли у вас аккаунт? y/n");

            char select = ReadKey().KeyChar;
                switch (select)
                {
                    case 'y':

                        check = true;
                        break;
                    case 'n':
                        Clear();
                        client.CreateAccount(bank);
                        bank.clients[bank.clients.Count-1].SaveUserInfo(test);
                        check = true;
                        break;
                    default:
                        Clear();
                        break;
                }

            }

            
        
            Account account = new Account();
            do
            {
                SetCursorPosition(FOURTHYFIVE, SEVEN);
                ForegroundColor = key == ZERO ? ConsoleColor.Green : ConsoleColor.White; WriteLine("->Вывод баланса на экран");
                SetCursorPosition(FOURTHYFIVE, EIGHT);
                ForegroundColor = key == ONE ? ConsoleColor.Green : ConsoleColor.White; WriteLine("->Пополнить счет");
                SetCursorPosition(FOURTHYFIVE, NINE);
                ForegroundColor = key == TWO ? ConsoleColor.Green : ConsoleColor.White; WriteLine("->Снять деньги со счета");
                SetCursorPosition(FOURTHYFIVE, TEN);
                ForegroundColor = key == THREE ? ConsoleColor.Green : ConsoleColor.White; WriteLine("->Выход");

                button = ReadKey().Key;


                if (button == ConsoleKey.DownArrow && key != THREE)
                {
                    key++;
                }

                else if (button == ConsoleKey.UpArrow && key != ZERO)
                {
                    key--;
                }

                else if (button == ConsoleKey.Enter)
                {
                    if (key == ZERO)
                    {
                        WriteLine(bank.Print(client, account));

                        ReadKey();
                        Clear();
                    }

                    else if (key == ONE)
                    {
                        SetCursorPosition(FOURTHYFIVE, TWELWE);
                        WriteLine("Введите сумму которую хотите внести на счет");
                        SetCursorPosition(FOURTHYFIVE, TWELWE + ONE);
                        isPars = int.TryParse(ReadLine(),out deposit);
                        if (isPars == true)
                        {
                            SetCursorPosition(FOURTHYFIVE, TWELWE + TWO);
                            bank.ReplenishAmount(account, deposit);
                        }
                        else
                        {
                            WriteLine("\nНе коректный ввод данных, пожалуйста в следущий раз введите данные коректно.");
                            WriteLine("\nДля продолжение нажимите на любую клавишу. ");
                            ReadKey();
                        }
                        Clear();
                    }

                    else if (key == TWO)
                    {
                        SetCursorPosition(FOURTHYFIVE, TWELWE);
                        WriteLine("Введите сумму которую хотите снять со счета");
                        SetCursorPosition(FOURTHYFIVE, TWELWE+ONE);
                        isPars = int.TryParse(ReadLine(), out deposit);
                        if (isPars == true)
                        {
                            SetCursorPosition(FOURTHYFIVE, TWELWE+TWO);
                            bank.PullAmount(account, deposit);
                        }
                        else
                        {
                            WriteLine("\nНе коректный ввод данных, пожалуйста в следущий раз введите данные коректно.");
                            WriteLine("\nДля продолжение нажимите на любую клавишу. ");
                            ReadKey();
                        }

                        Clear();
                    }

                    else if (key == THREE)
                    {

                        Environment.Exit(ZERO);
                    }

                }

            } while (true);
        }
    }
}
