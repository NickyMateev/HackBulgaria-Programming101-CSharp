using System;

namespace Appointments_intersection
{
    class AppointmentsIntersection
    {
        static void FindIntersectingAppointments(DateTime[] startDates, TimeSpan[] durations)
        {
            TimeSpan intersection;
            DateTime[] endDates = new DateTime[startDates.Length];

            for (int i = 0; i < startDates.Length; i++)
                endDates[i] = startDates[i] + durations[i];

            for (int i = 0; i < startDates.Length - 1; i++)
            {
                for (int j = i + 1; j < startDates.Length; j++)
                {
                    if (startDates[i] < endDates[j] && endDates[i] > startDates[j])
                    {
                        intersection = GetIntersection(startDates, endDates, i, j);
                        Console.WriteLine("The appointment starting at {0:dd/MM/yyyy H:mm} intersects the appointment starting at {1:dd/MM/yyyy H:mm} with exactly {2} minutes.\n", startDates[i], startDates[j], intersection.Minutes);
                    }
                }
            }
        }

        static TimeSpan GetIntersection(DateTime[] startDates, DateTime[] endDates, int i, int j)   // i and j are the corresponding indexes to each appointment
        {
            TimeSpan intersection;
            if (startDates[i] < startDates[j] && endDates[i] > startDates[j])
                intersection = (endDates[i] - startDates[j]);
            else if (startDates[i] > startDates[j] && endDates[j] > startDates[i])
                intersection = endDates[j] - startDates[i];
            else if (startDates[i] < startDates[j] && endDates[i] > endDates[j])
                intersection = endDates[j] - startDates[j];
            else if (startDates[j] < startDates[i] && endDates[j] > endDates[i])
                intersection = endDates[i] - startDates[i];
            else
                throw new ArgumentException("ERROR: Unknown intersection period.");

            return intersection;
        }


        static void Main()
        {
            DateTime[] startDates = new DateTime[]
            {
                new DateTime(2015, 11, 29, 07, 00, 00),
                new DateTime(2015, 11, 29, 07, 20, 00),
                new DateTime(2015, 11, 29, 07, 40, 00),
            };

            TimeSpan[] durations = new TimeSpan[]
            {
                new TimeSpan(00, 45, 00),
                new TimeSpan(00, 10, 00),
                new TimeSpan(00, 30, 00)
            };

            FindIntersectingAppointments(startDates, durations);
        }
    }
}