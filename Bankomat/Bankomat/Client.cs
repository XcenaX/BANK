using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;

namespace Bankomat
{
    public class Client
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }  
        public Account account { get; set; }

        public Client(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            account = new Account();
        }

        public Client()
        {
            FirstName = "";
            LastName = "";
            account = new Account();
        }

        public void CreateAccount(Bank bank)
        {
            Client client = new Client();
            int password = new Random().Next(1000, 9999);
            int id = new Random().Next(100000000, 999999999);

            int isPassword;
            string sayInfo = "Введите exit чтобы отменить регистрацию";

            WriteLine(sayInfo);

            WriteLine("Введите фамилию:");
            string lastName = ReadLine();
            

            WriteLine("\nВведите имя:");
            string firstName = ReadLine();
            string IIN;
            while (true)
            {
                WriteLine("\nВведите ваш ИИН:");
                IIN = ReadLine();

                if (bank.CheckSameAccount(IIN))
                {
                    Clear();
                    WriteLine("Пользователь с таким ИИН уже существует!");
                    WriteLine(sayInfo);
                }
                else break;
            }
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
                client.FirstName = firstName;
                client.LastName = lastName;
                client.account.Id = id;
                client.account.IIN = IIN;
                client.account.Password = password;
                

                bank.AddAccount(client);
            }
        }


        public void SaveUserInfo(string path)
        {
            var pathOfDirectory = path + "/" + account.Id.ToString();
            Directory.CreateDirectory(pathOfDirectory);

            var pathOfFile = pathOfDirectory + "/info.txt";
            StreamWriter writer = new StreamWriter(pathOfFile);
            // FileStream file = new FileStream(pathOfFile, FileMode.OpenOrCreate);

            var data = ("Имя: " + FirstName);
            // var buf = Convert.ToByte(data);
            writer.WriteLine(data);

            // buf = Convert.ToByte("Отчество: " + LastName);
            writer.WriteLine("Отчество: " + LastName);

            // buf = Convert.ToByte("Id: " + account.Id);
            writer.WriteLine("Id: " + account.Id);

            // buf = Convert.ToByte("Пароль: " + account.Password);
            writer.WriteLine("Пароль: " + account.Password);
            writer.Close();
        }

        public string LoadUserInfo(string path)
        {
            var pathOfFile = path + "/" + account.IIN;
            StreamReader reader = new StreamReader(pathOfFile);

            var data = reader.ReadToEnd();

            return data;
        }

        public void LogIn(Bank bank)
        {
            WriteLine("Чтобы войти введите либо ИИН или телефон: ");
            var data = ReadLine();



        }
            

    }
}
