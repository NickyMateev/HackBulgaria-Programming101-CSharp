using System.Collections;
using System.Collections.Generic;

namespace Cash_Desk
{
    public class BatchBill: IEnumerator, IEnumerable
    {
        private List<Bill> batch;
        private int position = -1;  // we need this when using IEnumerator

        public object Current       // IEnumerator
        {
            get
            {
                return batch[position];
            }
        }

        public BatchBill(List<Bill> batch)
        {
            this.batch = batch;
        }

        public int Count()
        {
            return batch.Count;
        }

        public int Total()
        {
            int sum = 0;
            foreach (var bill in batch)
            {
                sum += bill.Value();
            }
            return sum;
        }

        public override string ToString()
        {
            return string.Format("Number of bills: {0}; Total value: ${1}", Count(), Total());
        }

        public bool MoveNext()  // IEnumerator
        {
            position++;
            return (position < batch.Count);
        }

        public void Reset()     // IEnumerator
        {
            position = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)batch).GetEnumerator();
        }
    }
}