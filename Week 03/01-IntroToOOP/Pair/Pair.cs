namespace Pair
{
    class Pair
    {

        private readonly int pairA;
        private readonly int pairB;
        
        public Pair(int a, int b)
        {
            this.pairA = a;
            this.pairB = b;
        }

        public override string ToString()
        {
            return "(" + pairA + ", " + pairB + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj is Pair)
            {
                Pair obj1 = this;
                Pair obj2 = (Pair)obj;

                if (obj1.pairA == obj2.pairA && obj1.pairB == obj2.pairB)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }


        public static bool operator ==(Pair a, Pair b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Pair a, Pair b)
        {
            return !(a.Equals(b));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + pairA.GetHashCode();
                hash = hash * 23 + pairB.GetHashCode();
                return hash;
            }
        }

    }
}