using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadstart = new ThreadStart(Method);
            Thread thread = new Thread(threadstart);
            thread.Start();
        }

        static void Method()
        {
            int number = 1;
            while (true)
            {
                ParameterizedThreadStart threadstart = new ParameterizedThreadStart(Client);
                Thread thread = new Thread(threadstart);
                Console.ReadKey();
                thread.Start($"Пользователь #{number}" as object);
                number++;
            }
        }

        static void Client(object obj)
        {
            Console.WriteLine($"{DateTime.Now.TimeOfDay}\t{obj as string} подключился\n");
            Random rnd = new Random();
            while (true)
            {
                Thread.Sleep(rnd.Next(5000, 25000));
                switch (rnd.Next(0, 5))
                {
                    case 0:
                        Console.WriteLine($"{DateTime.Now.TimeOfDay}\t{obj as string} подписался на новости\n");
                        break;
                    case 1:
                        Console.WriteLine($"{DateTime.Now.TimeOfDay}\t{obj as string} начал чат\n");
                        break;
                    case 2:
                        Console.WriteLine($"{DateTime.Now.TimeOfDay}\t{obj as string} купил продукцию в магазине\n");
                        break;
                    case 3:
                        Console.WriteLine($"{DateTime.Now.TimeOfDay}\t{obj as string} отправил письмо\n");
                        break;
                    case 4:
                        Console.WriteLine($"{DateTime.Now.TimeOfDay}\t{obj as string} отключился\n");
                        return;
                    default:
                        break;
                }
            }
        }
    }
}