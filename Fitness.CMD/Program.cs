using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFitness.BL.Controller;
using System.Runtime.CompilerServices;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас вітає програма Fitness");

            Console.WriteLine("Введіть name користувача: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введіть стать: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вага");
                var height = ParseDouble("зріст");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введіть дату народження (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильний формат дати народження");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
            {
                while (true)
                {
                    Console.Write($"Введіть {name}: ");
                    if (double.TryParse(Console.ReadLine(), out double value))
                    {
                    return value;
                    }
                    else
                    {
                        Console.WriteLine($"Неправильний формат {name}");
                    }
                }
            }
    }
}
