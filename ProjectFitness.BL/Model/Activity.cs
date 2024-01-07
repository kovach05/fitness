using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }
        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesPerMinute) 
        {
            //  ПЕРЕВІРКА
            name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
