using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.Entities
{
    public class Award
    {
        int id;
        string title;

        public Award(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
        public Award(string title)
        {
            this.title = title;
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
    }
}
