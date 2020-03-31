using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.DAL
{
    public interface IUserAwardsBase
    {
        string AddAwardForUser(int idAward, int idUser);
        string DeleteAwardForUser(int idAward, int idUser);
        IEnumerable<SSU.ThreeLayer.Entities.User> GetUsersForAward(int idAward);
        IEnumerable<SSU.ThreeLayer.Entities.Award> GetAwardsForUser(int idUser);
    }
}
