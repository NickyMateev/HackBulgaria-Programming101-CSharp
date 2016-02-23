using System;
using Notify_Collection;
using StudentClass;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            NotifyCollection<Student> collection = new NotifyCollection<Student>();
            collection.PropertyChanged += (s, e) => { Console.WriteLine(e.PropertyName); };
            collection.Add(new Student("Pesho", 73421, 5));
            collection.Add(new Student("Gosho", 73422, 2));
            collection.Add(new Student("Drago", 73423, 7));

        }
    }
}