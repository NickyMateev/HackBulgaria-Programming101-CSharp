using System;
using AnonymousAggregatorMethod;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            AggregatorMethod aggregator = new AggregatorMethod();
            aggregator.AverageChanged += delegate (object sender, EventArgs e)
            {
                AggregatorMethod agg = (AggregatorMethod)sender;
                Console.WriteLine("Average changed!\nNew average: {0}", agg.Average);
            };

            aggregator.AddNumber(10);
            aggregator.AddNumber(3);
        }
    }
}
