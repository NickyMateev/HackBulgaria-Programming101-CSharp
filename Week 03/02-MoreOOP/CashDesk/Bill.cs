namespace Cash_Desk
{
    public class Bill
    {
        private int amount;

        public Bill(int amount)
        {
            this.amount = amount;
        }

        public override string ToString()
        {
            return string.Format("A ${0} bill", amount);
        }

        public override bool Equals(object obj)
        {
            if (obj is Bill)
            {
                Bill bill1 = this;
                Bill bill2 = (Bill)obj;

                if (bill1.amount == bill2.amount)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(Bill bill1, Bill bill2)
        {
            return bill1.Equals(bill2);
        }

        public static bool operator !=(Bill bill1, Bill bill2)
        {
            return !(bill1.Equals(bill2));
        }

        public int Value()
        {
            return amount;
        }

        public static explicit operator int(Bill bill)
        {
            return bill.Value();
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