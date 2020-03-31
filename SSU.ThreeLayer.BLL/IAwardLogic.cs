using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.BLL
{
    public interface IAwardLogic
    {
        string AddAward(string title);
        string DeleteByID(int idAward);
        string ShowAllAwards();
        string Find(string title);
        string SortByTitle();
    }
}
