using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.BLL
{
    public class AwardLogic : IAwardLogic
    {
        SSU.ThreeLayer.DAL.AwardBase awardBase = new DAL.AwardBase();
        public string AddAward(string title)
        {
            return awardBase.AddAward(new Entities.Award(title));
        }

        public string DeleteByID(int idAward)
        {
            return awardBase.DeleteAward(idAward);
        }

        public string Find(string title)
        {
            string temp = "Все награды с названием " + title + "\nidAward title\n";
            foreach (var x in awardBase.FindByTitle(title))
            {
                temp += $"{x.Id} {x.Title}\n";
            }
            return temp;
        }

        public string ShowAllAwards()
        {
            string temp = $"Все награды\nidAward title\n";
            foreach (var x in awardBase.ShowAllAwards())
            {
                temp += $"{x.Id} {x.Title}\n";
            }
            return temp;
        }

        public string SortByTitle()
        {
            string temp = $"Отсортированные по названию награды\nidAward title\n";
            foreach (var x in awardBase.SortByTitle())
            {
                temp += $"{x.Id} {x.Title}\n";
            }
            return temp;
        }
    }
}
