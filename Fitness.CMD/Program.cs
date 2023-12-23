using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFitness.BL.Controller;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас вітає програма Fitness");

            Console.WriteLine("Введіть name користувача: ");
            var name = Console.ReadLine();

            Console.WriteLine("Введіть gender: ");
            var gender = Console.ReadLine();

            Console.WriteLine("Введіть дату birth: ");
            var birthDate = DateTime.Parse(Console.ReadLine()); //TODO: Переписати

            Console.WriteLine("Введіть weight: ");
            var weight = Double.Parse(Console.ReadLine());

            Console.WriteLine("Введіть htight: ");
            var height = Double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
