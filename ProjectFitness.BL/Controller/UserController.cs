using ProjectFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFitness.BL.Controller
{
    /// <summary>
    /// Контроллер користувача.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Користувач.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Сторення нового контроллера
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            //TODO: Перевірка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TODO: Що робити якщо користувача не прочитали???
            }
        }
        /// <summary>
        /// Створити дані користувача
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получити дані користувача.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>

      
    }
}
