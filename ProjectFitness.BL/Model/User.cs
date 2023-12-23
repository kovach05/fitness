using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFitness.BL.Model
{
    /// <summary>
    /// Користувач
    /// </summary>
    [Serializable]
    public class User
    {
        #region Властивості
        /// <summary>
        /// Ім'я
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Стать
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата народження
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вага
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Зріст
        /// </summary>
        public double Height { get; set; }
        #endregion
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Перевірка умови
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("The name cannot be empty or null.", nameof(name));
            }        
            if(gender == null)
            {
                throw new ArgumentNullException("The gender name cannot be null.", nameof(name));
            }
            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birthDate));
            }
            if(weight <= 0)
            {
                throw new ArgumentException("The weight cannot be less than or equal to 0.", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentException("The height cannot be less than or equal to 0.", nameof(height));
            }
            #endregion

            
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
