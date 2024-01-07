using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectFitness.BL.Controller;
using System.Runtime.CompilerServices;
using ProjectFitness.BL.Model;
using System.Globalization;
using System.Resources;
using System.Data;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture = new CultureInfo("uk-UA");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messeges_uk-UA", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введіть стать: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата народження");
                var weight = ParseDouble("вага");
                var height = ParseDouble("зріст");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);


            while (true)
            {
                Console.WriteLine("Що ви хочете зробити?");
                Console.WriteLine("Е - ввести прийом їжі");
                Console.WriteLine("A - введіть вправу");
                Console.WriteLine("Q - вихід");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} з {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введіть назву вправи: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("витрата енергії в хвилину");

            var begin = ParseDateTime("начало вправи");
            var end = ParseDateTime("кінець вправи");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введіть назву продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорійність");
            var prots = ParseDouble("білки");
            var fats = ParseDouble("жири");
            var carbs = ParseDouble("вуглеводи");

            var weight = ParseDouble("Вага порції");
            var product = new Food(food, calories, fats, carbs, prots);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введіть {value} (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неправильний формат {value}");
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
                        Console.WriteLine($"Неправильний формат поля {name}");
                    }
                }
            }
    }
}
