using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer
{
    class Program
    {
        static void Main()
        {
            BLL.AwardLogic awardLogic = new BLL.AwardLogic();
            BLL.UserLogic userLogic = new BLL.UserLogic();
            BLL.UserAwardsLogic userAwardsLogic = new BLL.UserAwardsLogic();
            bool isRunning = true;
            while (isRunning)
            {
                int choice;
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1) Добавить пользователя");
                Console.WriteLine("2) Добавить награду");
                Console.WriteLine("3) Добавить награду для пользователя");
                Console.WriteLine("4) Удалить пользователя");
                Console.WriteLine("5) Удалить награду");
                Console.WriteLine("6) Удалить награду для пользователя");
                Console.WriteLine("7) Показать всех пользователей");
                Console.WriteLine("8) Показать все награды");
                Console.WriteLine("9) Показать награды для пользователя");
                Console.WriteLine("10) Показать пользователей с наградой");
                Console.WriteLine("11) Найти пользователя");
                Console.WriteLine("12) Найти награду");
                Console.WriteLine("13) Отсортировать пользователей по имени");
                Console.WriteLine("14) Отсортировать награды по названию");
                Console.WriteLine("15) Выйти из программы");
                Console.Write("Выбор: ");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case (1):
                        Console.Write("Введите имя: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите дату рождения в формате ДД-ММ-ГГГГ: ");
                        DateTime dateOfBorn;
                        DateTime.TryParse(Console.ReadLine(), out dateOfBorn);
                        Console.Write("Полных лет: ");
                        int age;
                        int.TryParse(Console.ReadLine(), out age);
                        Console.WriteLine(userLogic.AddUser(name, dateOfBorn, age));
                        break;
                    case (2):
                        Console.Write("Введите название награды: ");
                        string title = Console.ReadLine();
                        Console.WriteLine(awardLogic.AddAward(title));
                        break;
                    case (3):
                        Console.Write("Введите id пользователя: ");
                        int idUser;
                        int.TryParse(Console.ReadLine(), out idUser);
                        Console.Write("Введите id награды: ");
                        int idAward;
                        int.TryParse(Console.ReadLine(), out idAward);
                        Console.WriteLine(userAwardsLogic.AddAwardForUser(idAward, idUser));
                        break;
                    case (4):
                        Console.Write("Введите id пользователя: ");
                        int.TryParse(Console.ReadLine(), out idUser);
                        Console.WriteLine(userLogic.DeleteByID(idUser));
                        break;
                    case (5):
                        Console.Write("Введите id награды: ");
                        int.TryParse(Console.ReadLine(), out idAward);
                        Console.WriteLine(awardLogic.DeleteByID(idAward));
                        break;
                    case (6):
                        Console.Write("Введите id награды: ");
                        int.TryParse(Console.ReadLine(), out idAward);
                        Console.Write("Введите id пользователя:");
                        int.TryParse(Console.ReadLine(), out idUser);
                        Console.WriteLine(userAwardsLogic.DeleteAwardForUser(idAward, idUser));
                        break;
                    case (7):
                        Console.WriteLine(userLogic.ShowAllUsers());
                        break;
                    case (8):
                        Console.WriteLine(awardLogic.ShowAllAwards());
                        break;
                    case (9):
                        Console.Write("Введите id пользователя: ");
                        int.TryParse(Console.ReadLine(), out idUser);
                        Console.WriteLine(userAwardsLogic.GetAwardsForUser(idUser));
                        break;
                    case (10):
                        Console.Write("Введите id награды: ");
                        int.TryParse(Console.ReadLine(), out idAward);
                        Console.WriteLine(userAwardsLogic.GetUsersForAward(idAward));
                        break;
                    case (11):
                        Console.Write("Введите имя пользователя: ");
                        Console.WriteLine(userLogic.Find(Console.ReadLine()));
                        break;
                    case (12):
                        Console.Write("Введите название награды: ");
                        Console.WriteLine(awardLogic.Find(Console.ReadLine()));
                        break;
                    case (13):
                        Console.WriteLine(userLogic.SortByName());
                        break;
                    case (14):
                        Console.WriteLine(awardLogic.SortByTitle());
                        break;
                    case (15):
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Действие выбрано некорректно!");
                        break;
                }
            }
        }
    }
}
