using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousAggregatorMethod
{
    public class AggregatorMethod
    {
        private List<int> list = new List<int>();
        public event EventHandler AverageChanged;

        public double Average { get; private set; } = 0;

        private double GetAverage()
        {
            double avg = 0;
            foreach (int num in list)
                avg += num;

            return avg / list.Count;
        }

        public void AddNumber(int number)
        {
            list.Add(number);
            double newAverage = GetAverage();

            if (Average != newAverage)
            {
                Average = newAverage;
                if (AverageChanged != null)
                    AverageChanged(this, new EventArgs());
            }
        }

    }
}