using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.DAL
{
    public interface IUserBase
    {
        string AddUser(SSU.ThreeLayer.Entities.User user);
        string DeleteUser(int idUser);
        IEnumerable<SSU.ThreeLayer.Entities.User> ShowAllUsers();
        IEnumerable<SSU.ThreeLayer.Entities.User> FindUser(string name);
        IEnumerable<SSU.ThreeLayer.Entities.User> SortByName();

    }
}
