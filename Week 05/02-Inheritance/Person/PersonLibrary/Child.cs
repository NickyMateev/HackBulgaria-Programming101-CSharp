using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary
{
    public class Child : Person, IChildDailyActivities
    {
        private List<Toy> listOfToys;

        public Child(string name, string gender)
        {
            this.name = name;
            this.gender = gender;
            listOfToys = new List<Toy>();
        }

        public void Play()
        {
            Console.WriteLine("{0} is playing right now...", name);
        }

        public int NumberOfToys()
        {
            return listOfToys.Count;
        }

        public void AddToy(Toy toy)
        {
            listOfToys.Add(toy);
        }

        public void TakeAwayToy(Toy toy)
        {
            listOfToys.Remove(toy);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Name: " + name);
            str.AppendLine("Gender: " + gender);
            str.Append("Number of toys: " + NumberOfToys());
            return str.ToString();
        }
    }
}