using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cash_Desk
{
    public class BatchCoin: IEnumerator, IEnumerable
    {
        private List<Coin> batch;
        private int position = -1;  // we need this for the IEnumerator

        public object Current   // IEnumerator
        {
            get
            {
                return batch[position];
            }
        }

        public BatchCoin(List<Coin> batch)
        {
            this.batch = batch;
        }

        public int Count()
        {
            return batch.Count();
        }

        public int Total()
        {
            int sum = 0;
            foreach (var coin in batch)
            {
                sum += coin.Value();
            }
            return sum;
        }

        public override string ToString()
        {
            return string.Format("Number of coins: {0}; Total value: {1}c", Count(), Total());
        }

        public bool MoveNext()  // IEnumerator
        {
            position++;
            return (position < batch.Count());
        }

        public void Reset()     // IEnumerator
        {
            position = 0;
        }

        public IEnumerator GetEnumerator()      // IEnumerable
        {
            return ((IEnumerable)batch).GetEnumerator();
        }
    }
}
