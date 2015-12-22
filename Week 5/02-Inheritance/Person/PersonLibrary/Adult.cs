using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary
{
    public class Adult : Person, IAdultDailyActivities
    {
        private List<Child> kids;

        public Adult(string name, string gender)
        {
            this.name = name;
            this.gender = gender;
            kids = new List<Child>();
        }
        
        public bool IsBoring { get; set; }

        public void Work()
        {
            Console.WriteLine("{0} is working right now...", name);
        }

        public int NumberOfKids()
        {
            return kids.Count;
        }

        public void AddChild(Child child)
        {
            kids.Add(child);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Name: " + name);
            str.AppendLine("Gender: " + gender);
            str.Append("Number of children: " + NumberOfKids());
            return str.ToString();
        }
    }
}