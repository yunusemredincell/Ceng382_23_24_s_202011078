using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ceng382_23_24_s_202011078;

public class ReservationHandler
{
    private Reservation?[,] reservations;

    public ReservationHandler(int day, int hour) // constructor created for 7 days and 24 hours from Program.cs part
    {
        reservations = new Reservation?[day, hour];

    }

    public void addReservation(Reservation r)
    {
        if (r.room != null && r.room.capacity >= 1) // control capacity
        {
            int day = (int)r.Date.DayOfWeek - 1; // day value between 0-6
            int hour = (int)r.Time.Hour; // hour value between 0-23
            if (reservations[day, hour] == null) // if it is availabke
            {
                reservations[day, hour] = r;
                r.room.capacity--; // decreased 1 from capacity
                Console.WriteLine("Reservation added.");
            }
            else
                Console.WriteLine("Another reservation exist in this time.");
        }
        else
            Console.WriteLine("Unsufficent Capacity for this reservation");

    }

    public void deleteReservation(Reservation r)
    {
        int day = (int)r.Date.DayOfWeek - 1; // day value between 0-6
        int hour = (int)r.Time.Hour; // hour value between 0-23

        if (reservations[day, hour] != null && reservations[day, hour].Equals(r)) // check reservation is not null and there exist reservation
        {
            reservations[day, hour] = null; // removed reservation
            r.room.capacity++;
            Console.WriteLine("\n\n$Reservation removed!");
        }
        else
            Console.WriteLine("No found such a reservation.");



    }
    public void displayWeeklySchedule() // display the week schedule. I referenced from some websites to write beauty like using PadLeft etc.
    {

        DateTime today = DateTime.Today;
        int currentDayOfWeek = (int)today.DayOfWeek;
        string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        for (int i = 0; i < daysOfWeek.Length; i++)
        {
            if (i == (int)currentDayOfWeek - 1)
            {
                Console.Write($"{"| " + daysOfWeek[i]} (Today)".PadLeft(30) + " | ");
            }
            else if ((int)currentDayOfWeek - 1 > i)
            {
                Console.Write($"{"| " + daysOfWeek[i]}".PadLeft(25) + " | ");
            }
            else
            {
                Console.Write($"{"| " + daysOfWeek[i]}".PadRight(20) + " | ");
            }
        }

        Console.WriteLine();

        Console.WriteLine(new string('-', 25 * 7));
        for (int hour = 0; hour < 24; hour++) // Including all hours of the day
        {
            if (hour < 10)
            {
                Console.Write($"{"| 0" + hour + ":00-"}");
            }
            else
            {
                Console.Write($"{"| " + hour + ":00-"}");
            }

            int nextHour = (hour + 1) % 24; // range setting for hours. 
            if (nextHour < 10)
            {
                Console.Write($"{"0" + nextHour + ":00"}".PadRight(12) + " | ");
            }
            else
            {
                Console.Write($"{nextHour + ":00"}".PadRight(12) + " | ");
            }

            for (int day = 0; day < 7; day++) // write reservation
            {
                var r = reservations[day, hour];
                if (r != null)
                {
                    Console.Write($"{r.reserverName}-{r.room.roomName}".PadRight(20) + " | ");
                }
                else
                {
                    Console.Write("".PadRight(20) + " | ");
                }
            }
            Console.WriteLine();
        }
    }
}