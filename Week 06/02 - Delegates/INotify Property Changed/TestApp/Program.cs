using System;
using System.Collections.Generic;
using StudentClass;
using System.ComponentModel;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student("Pesho", 71344, 5),
                new Student("Gosho", 71245, 7),
                new Student("Grisho", 72323, 2),
                new Student("Suzzy", 72003, 4)
            };

            studentList[0].PropertyChanged += Program_PropertyChanged;
            studentList[1].PropertyChanged += Program_PropertyChanged;
            studentList[2].PropertyChanged += Program_PropertyChanged;
            studentList[3].PropertyChanged += Program_PropertyChanged;

            studentList[0].ChangeNumberOfExamsLeft(2);
            studentList[0].ChangeFacultyNumber(74323);

            studentList[1].ChangeName("Ivan");

        }

        private static void Program_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("Changed property: " + e.PropertyName);
            Console.WriteLine("Object hash code: " + sender.GetHashCode());
            Console.WriteLine("Property hash code: " + e.GetHashCode() + '\n');
        }
    }
}