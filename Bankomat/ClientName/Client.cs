using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ClientName
{
    public class Client
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }  

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void CreateAccount(Bank bank)
        {
            int password = new Random().Next(1000, 9999);
            int id = new Random().Next(100000000, 999999999);

            int isPassword;



            WriteLine("Введите фамилию:");
            string lastName = ReadLine();

            WriteLine("\nВведите имя:");
            string firstName = ReadLine();

            Clear();

            if (lastName.Length > 0 && firstName.Length > 0)
            {
                WriteLine("Номер вашего лицевого счёта: " + id);
                WriteLine("\nВаш ПИН-КОД: " + password);
                WriteLine("\nДля продолжение нажимите на любую клавишу. ");
                ReadKey();
            }

            else
            {
                WriteLine("\nНе коректный ввод данных, пожалуйста в следущий раз введите данные коректно.");
                ReadKey();
                Environment.Exit(0);
            }

            
            int count = 3;
            bool stop = true;
            

            while (stop == true)
            {

                WriteLine("\nВведите ваш ПИН-КОД, у вас есть " + count + " попытки");
                bool isPars = int.TryParse(ReadLine(), out isPassword);

                if (isPars == true)
                {
                    if (isPassword == password)
                    {
                        WriteLine("\nВсё коректно.");
                        WriteLine("\nДля продолжение нажимите на любую клавишу. ");
                        ReadKey();

                        stop = false;
                    }
                    if (count == 0)
                    {
                        WriteLine("\nВы исчерпали количество попыток. ");
                        WriteLine("\nДля продолжение нажимите на любую клавишу. ");
                        ReadKey();
                        Environment.Exit(0);
                    }
                    count--;
                }

                else
                {
                    WriteLine("\nНе коректный ввод данных, пожалуйста в следущий раз введите данные коректно.");
                    WriteLine("\nДля продолжение нажимите на любую клавишу. ");
                    ReadKey();
                    Environment.Exit(0);
                }

                Clear();
            }
        }

    }
}
