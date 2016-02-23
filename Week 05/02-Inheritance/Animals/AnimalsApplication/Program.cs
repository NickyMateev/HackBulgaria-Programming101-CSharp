using System;
using System.Collections.Generic;
using Animals;

namespace AnimalsApplication
{
    class Program
    {
        static void Main()
        {
            List<Animal> listOfAnimals = new List<Animal>();
            listOfAnimals.Add(new Cat());
            listOfAnimals.Add(new Dog());
            listOfAnimals.Add(new Crocodile());
            listOfAnimals.Add(new Owl());
            listOfAnimals.Add(new Shark());

            foreach (var animal in listOfAnimals)
            {
                animal.Move();
                animal.Eat();
                animal.GiveBirth();

                if (animal is Mammal)
                {
                    Mammal mammal = (Mammal)animal;
                    mammal.Greet();
                }
                else if (animal is Reptile)
                {
                    Reptile reptile = (Reptile)animal;
                    reptile.Greet();
                }
                else if (animal is Bird)
                {
                    Bird bird = (Bird)animal;
                    bird.MakeNest();
                    bird.Fly();
                }

                Console.WriteLine("Has constant temperature? -> {0}\n", animal.hasConstTemp);
            }
        }
    }
}