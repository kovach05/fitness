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
    public class UserController : ControllerBase
    {

        private const string USER_FILE_NAME = "users.dat";
        /// <summary>
        /// Користувач.
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Сторення нового контроллера
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Ім'я користувача не може бути пустим", nameof(userName));
            }

            Users = GetUserData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// Отримати збережений списк користувачів.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUserData()
        {
           return Load<List<User>>(USER_FILE_NAME) ?? new List<User>();
        }


        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Перевірка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Створити дані користувача
        /// </summary>
        public void Save()
        {
            Save(USER_FILE_NAME, Users);
        }
        /// <summary>
        /// Получити дані користувача.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"></exception>

      
    }
}
