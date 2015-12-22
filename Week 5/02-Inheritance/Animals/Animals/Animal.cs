using System;

namespace Animals
{
    public abstract class Animal 
    {
        public abstract void Move();
        public abstract void Eat();
        public abstract void GiveBirth();

        public bool hasConstTemp = true; 
    }

    public abstract class Mammal : Animal, ILandAnimal
    {
        public abstract void Greet();
    }

    public abstract class Reptile : Animal, ILandAnimal
    {
        public abstract void Greet();

        public Reptile()
        {
            hasConstTemp = false;
        }
    }

    public abstract class Fish : Animal, IWaterAnimal
    {
        public override void Move()
        {
            Swim();
        }

        public virtual void Swim()
        {
            Console.WriteLine("Fish is swimming");
        }
    }

    public abstract class Bird : Animal, IAirAnimal
    {
        public abstract void Fly();
        public abstract void MakeNest();        
    }

    public class Cat : Mammal
    {
        public override void Greet()
        {
            Console.WriteLine("Meow");
        }

        public override void Move()
        {
            Console.WriteLine("Cat is moving...");
        }

        public override void Eat()
        {
            Console.WriteLine("Cat is eating...");
        }

        public override void GiveBirth()
        {
            Console.WriteLine("Cat is giving birth...");
        }
    }

    public class Dog : Mammal
    {
        public override void Greet()
        {
            Console.WriteLine("Woof");
        }

        public override void Move()
        {
            Console.WriteLine("Dog is moving...");
        }

        public override void Eat()
        {
            Console.WriteLine("Dog is eating...");
        }

        public override void GiveBirth()
        {
            Console.WriteLine("Dog is giving birth...");
        }
    }

    public class Crocodile : Reptile
    {
        public override void Greet()
        {
            Console.WriteLine("The crocodile is greeting you... Hello... it's me.");
        }

        public override void Move()
        {
            Console.WriteLine("Crocodile is moving...");
        }

        public override void Eat()
        {
            Console.WriteLine("Crocodile is eating...");
        }

        public override void GiveBirth()
        {
            Console.WriteLine("Crocodile is giving birth...");
        }
    }

    public class Owl : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("Owl is flying...");
        }

        public override void Move()
        {
            Console.WriteLine("Owl is moving...");
        }

        public override void Eat()
        {
            Console.WriteLine("Owl is eating...");
        }

        public override void GiveBirth()
        {
            Console.WriteLine("Owl is giving birth...");
        }

        public override void MakeNest()
        {
            Console.WriteLine("Owl is making a nest...");
        }
    }

    public class Shark : Fish
    {
        public override void Swim()
        {
            Console.WriteLine("Shark is swimming...");
        }

        public override void Eat()
        {
            Console.WriteLine("Shark is eating...");
        }

        public override void GiveBirth()
        {
            Console.WriteLine("Shark is giving birth...");
        }
    }
}