namespace Lotto_Game
{
    public class Combination<T, U>
    {
        private T[] firstHalfValues;
        private U[] secondHalfValues;

        public Combination(T[] firstHalfValues, U[] secondHalfValues)
        {
            this.firstHalfValues = firstHalfValues;
            this.secondHalfValues = secondHalfValues;
            FirstHalf = firstHalfValues;
            SecondHalf = secondHalfValues;
        }

        public T[] FirstHalf { get; }
        public U[] SecondHalf { get; }

        public override bool Equals(object obj)
        {
            if (obj is Combination<T, U>)
            {
                Combination<T, U> obj1 = this;
                Combination<T, U> obj2 = (Combination<T, U>)obj;

                for (int i = 0; i < obj1.FirstHalf.Length; i++)
                {
                    if (!obj1.firstHalfValues[i].Equals(obj2.firstHalfValues[i]))
                        return false;
                    if (!obj1.secondHalfValues[i].Equals(obj2.secondHalfValues[i]))
                        return false;
                }

                return true;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + firstHalfValues[0].GetHashCode();
                hash = hash * 23 + firstHalfValues[1].GetHashCode();
                hash = hash * 23 + firstHalfValues[2].GetHashCode();
                hash = hash * 42 + secondHalfValues[0].GetHashCode();
                hash = hash * 42 + secondHalfValues[1].GetHashCode();
                hash = hash * 42 + secondHalfValues[2].GetHashCode();
                return hash;
            }
        }

    }
}