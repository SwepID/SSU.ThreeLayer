using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.Entities
{
    public class User
    {
        int id;
        string name;
        DateTime dateOfBirth;
        int age;
        List<Award> awards = new List<Award>();
        public User(int id, string name, DateTime dateOfBirth, int age)
        {
            this.Id = id;
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Age = age;
        }
        public User(string name, DateTime dateOfBirth, int age)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Age = age;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int Age { get => age; set => age = value; }
    }
}
