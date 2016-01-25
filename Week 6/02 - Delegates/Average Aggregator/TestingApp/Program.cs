using System;
using Average_Aggregator;

namespace TestingApp
{
    class Program
    {
        static void Main()
        {
            AverageAggregator avgAggregator = new AverageAggregator();
            avgAggregator.AverageChanged += AvgAggregator_AverageChanged;

            avgAggregator.AddNumber(3);
            avgAggregator.AddNumber(8);
            avgAggregator.AddNumber(8);
        }

        private static void AvgAggregator_AverageChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Average changed!");

            AverageAggregator avg = (AverageAggregator)sender;
            Console.WriteLine("New average: " + avg.Average);
        }
    }
}
