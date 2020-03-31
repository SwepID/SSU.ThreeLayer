using SSU.ThreeLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.DAL
{
    public interface IAwardBase
    {
        string AddAward(Award award);
        string DeleteAward(int idAward);
        IEnumerable<Award> ShowAllAwards();
        IEnumerable<Award> FindByTitle(string title);
        IEnumerable<Award> SortByTitle();
    }
}
