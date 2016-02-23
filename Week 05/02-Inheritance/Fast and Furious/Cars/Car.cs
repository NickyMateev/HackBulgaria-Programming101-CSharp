namespace Cars
{
    public abstract class Car
    {
        public abstract bool IsEcoFriendly(bool testing);
        
    }

    public abstract class GermanCars : Car
    {
        public abstract int Mileage { get; set; }
    }

    public class Audi : GermanCars
    {
        public override bool IsEcoFriendly(bool testing)
        {
            return IsEcoFriendly();
        }

        public bool IsEcoFriendly()
        {
            return true;
        }

        public override int Mileage { get; set; }
    }

    public class BMW : GermanCars
    {
        public override bool IsEcoFriendly(bool testing)
        {
            return IsEcoFriendly();
        }

        public bool IsEcoFriendly()
        {
            return true;
        }

        public override int Mileage { get; set; }
    }

    public class Volkswagen : GermanCars
    {
        public override bool IsEcoFriendly(bool testing)
        {
            return testing;
        }

        public override int Mileage { get; set; }
    }

    public class Honda : Car
    {
        public override bool IsEcoFriendly(bool testing)
        {
            return IsEcoFriendly();
        }

        public bool IsEcoFriendly()
        {
            return true;
        }
    }

    public class Skoda : Car
    {
        public override bool IsEcoFriendly(bool testing)
        {
            return IsEcoFriendly();
        }

        public bool IsEcoFriendly()
        {
            return true;
        }
    }
}