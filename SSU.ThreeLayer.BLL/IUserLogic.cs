using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.BLL
{
    public interface IUserLogic
    {
        string AddUser(string name, DateTime dateOfBirth, int age);
        string DeleteByID(int idUser);
        string ShowAllUsers();
        string Find(string name);
        string SortByName();
    }
}
