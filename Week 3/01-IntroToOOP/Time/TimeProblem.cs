using System;

namespace Time
{
    class TimeProblem
    {
        static void Main()
        {
            Time date = new Time(new DateTime(2015, 12, 1));
            Console.WriteLine(date.userDate);
        }
    }
}
