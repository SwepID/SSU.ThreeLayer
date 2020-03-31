using SSU.ThreeLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.BLL
{
    public class UserAwardsLogic : IUserAwardsLogic
    {
        DAL.UserAwardsBase userAwardsBase = new DAL.UserAwardsBase();
        public string AddAwardForUser(int idAward, int idUser)
        {
            return userAwardsBase.AddAwardForUser(idAward, idUser);
        }

        public string DeleteAwardForUser(int idAward, int idUser)
        {
            return userAwardsBase.DeleteAwardForUser(idAward, idUser);
        }

        public string GetAwardsForUser(int idUser)
        {
            string temp = $"Список наград пользователя с ID {idUser}\nidAward title\n";
            foreach (var x in userAwardsBase.GetAwardsForUser(idUser))
            {
                temp += $"{x.Id} {x.Title}\n";
            }
            return temp;
        }

        public string GetUsersForAward(int idAward)
        {
            string temp = $"Список пользователей с наградой ID {idAward}\nidUser userName dateOfBirth Age\n";
            foreach (var x in userAwardsBase.GetUsersForAward(idAward))
            {
                temp += $"{x.Id} {x.Name} {x.DateOfBirth} {x.Age}\n";
            }
            return temp;
        }
    }
}
