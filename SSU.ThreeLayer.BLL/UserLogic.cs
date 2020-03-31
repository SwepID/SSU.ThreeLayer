using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.BLL
{
    public class UserLogic : IUserLogic
    {
        SSU.ThreeLayer.DAL.UserBase userBase = new DAL.UserBase();
        public string AddUser(string name, DateTime dateOfBirth, int age)
        {
            return userBase.AddUser(new Entities.User(name, dateOfBirth, age));
        }

        public string DeleteByID(int idUser)
        {
            return userBase.DeleteUser(idUser);
        }

        public string Find(string name)
        {
            string temp = $"Все пользователи с именем {name}:\nidUser userName dateOfBirth Age\n";
            foreach (var x in userBase.FindUser(name))
            {
                temp += $"{x.Id} {x.Name} {x.DateOfBirth} {x.Age}\n";
            }
            return temp;
        }

        public string ShowAllUsers()
        {
            string temp = $"Список всех пользователей\nidUser userName dateOfBirth Age\n";
            foreach (var x in userBase.ShowAllUsers())
            {
                temp += $"{x.Id} {x.Name} {x.DateOfBirth} {x.Age}\n";
            }
            return temp;
        }

        public string SortByName()
        {
            string temp = "Список всех пользователей, отсортированных по имени\nidUser userName dateOfBirth Age\n";
            foreach (var x in userBase.SortByName())
            {
                temp += $"{x.Id} {x.Name} {x.DateOfBirth} {x.Age}\n";
            }
            return temp;
        }
    }
}
