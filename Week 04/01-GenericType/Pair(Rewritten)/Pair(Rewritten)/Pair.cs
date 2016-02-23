namespace Pair_Rewritten_
{
    public class Pair<T, U>
    {
        private readonly T pairA;
        private readonly U pairB;

        public Pair(T a, U b)
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
            if (obj is Pair<T, U>)
            {
                Pair<T, U> obj1 = this;
                Pair<T, U> obj2 = (Pair<T, U>)obj;

                if (obj1.pairA.Equals(obj2.pairA) && obj1.pairB.Equals(obj2.pairB))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(Pair<T, U> a, Pair<T, U> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Pair<T, U> a, Pair<T, U> b)
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