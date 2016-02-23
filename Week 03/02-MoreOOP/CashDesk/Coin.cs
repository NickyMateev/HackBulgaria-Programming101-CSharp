namespace Cash_Desk
{
    public class Coin
    {
        private int amount;

        public Coin(int amount)
        {
            this.amount = amount;
        }

        public override string ToString()
        {
            return string.Format("A {0}c coin", amount);
        }

        public override bool Equals(object obj)
        {
            if (obj is Coin)
            {
                Coin coin1 = this;
                Coin coin2 = (Coin)obj;

                if (coin1.amount == coin2.amount)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(Coin coin1, Coin coin2)
        {
            return coin1.Equals(coin2);
        }

        public static bool operator !=(Coin coin1, Coin coin2)
        {
            return !(coin1.Equals(coin2));
        }

        public int Value()
        {
            return amount;
        }

        public static explicit operator int (Coin coin)
        {
            return coin.Value();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + amount.GetHashCode();
                hash = hash * 23 + amount.GetHashCode();
                return hash;
            }
        }
    }
}
