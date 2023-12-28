using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get;  }
        /// <summary>
        /// Білки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жири
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Вулглеводи
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калорії за 100 гр продукта
        /// </summary>
        public double Calories { get; }
        public Food(string name) : this(name, 0,0,0,0)
        {
            // TODO: Перевірка

            Name = name;
        }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: Перевірка

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
