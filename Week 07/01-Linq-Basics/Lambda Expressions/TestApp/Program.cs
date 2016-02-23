using System;
using StudentClass;
using NotifyCollectionLambda;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            NotifyCollection<Student> collection = new NotifyCollection<Student>();
            collection.PropertyChanged += (s, e) => { Console.WriteLine(e.PropertyName); };

            collection.Add(new Student("Pesho", 75321, 2));
            collection.Add(new Student("Gosho", 73242, 5));
           
        }
    }
}