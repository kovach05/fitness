using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFitness.BL.Model
{
    /// <summary>
    /// Стать
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Назва
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Створити нову стать
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The gender name cannot be empty or null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
