using System;
using System.Collections.Generic;
using PersonLibrary;
using System.Drawing;

namespace PersonApplication
{
    class Program
    {
        static void Main()
        {
            List<Person> listOfPeople = new List<Person>();

            Adult Joe = new Adult("Joe", "Male");
            Adult Sarah = new Adult("Sarah", "Female");
            Child Natalia = new Child("Natalia", "Female");
            Child Bobby = new Child("Bobby", "Male");

            listOfPeople.Add(Joe);
            listOfPeople.Add(Sarah);
            listOfPeople.Add(Natalia);
            listOfPeople.Add(Bobby);

            Joe.AddChild(new Child("Tommy", "Male"));
            Sarah.AddChild(new Child("Kristin", "Female"));
            Sarah.AddChild(new Child("Jessica", "Female"));

            Natalia.AddToy(new Toy(Color.Cyan, new Size(100, 50)));
            Natalia.AddToy(new Toy(Color.Red, new Size(40, 90)));
            Natalia.AddToy(new Toy(Color.Gold, new Size(45, 65)));
            Bobby.AddToy(new Toy(Color.GreenYellow, new Size(120, 200)));

            Joe.IsBoring = true;
            Sarah.IsBoring = false;

            foreach (var person in listOfPeople)
            {
                if (person is Child)
                {
                    Child child = (Child)person;
                    Console.WriteLine(child.ToString());
                    child.Play();
                }
                else if (person is Adult)
                {
                    Adult adult = (Adult)person;
                    Console.WriteLine(adult.ToString());
                    adult.Work();
                    Console.WriteLine("Is {0} boring? -> {1}", adult.name, true == adult.IsBoring ? "Yes" : "No");
                }
                else
                    throw new ArgumentException("ERROR: Invalid person!");

                Console.WriteLine();
            }
        }
    }
}