using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.BLL
{
    public interface IUserAwardsLogic
    {
        string AddAwardForUser(int idAward, int idUser);
        string DeleteAwardForUser(int idAward, int idUser);
        string GetUsersForAward(int idAward);
        string GetAwardsForUser(int idUser);
    }
}
