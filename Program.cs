using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ceng382_23_24_s_202011078;
class Program
{

    static void CreateReservation(int year, int month, int day, int hour, string reserverName, Reservation reservation, Room room)
    {
        DateTime dateTime = new DateTime(year, month, day, hour, 0, 0); // take time
        DateTime today = DateTime.Today; // take current local time 

        if (dateTime < today || (dateTime - today).TotalDays > 7) // control out of the week  
        {
            Console.WriteLine("Reservation must be made for the next 7 days.");
        }
        else
        {
            reservation.Date = dateTime;
            reservation.Time = dateTime;
            reservation.reserverName = reserverName;
            reservation.room = room;

            Console.WriteLine($"Reservation created for {reservation.reserverName}  at {reservation.Time:HH:mm}   for room {reservation.room.roomName}.");
        }
    }
    static void Main(string[] args)
    {
        //path to json
        // todo inside try catch
        string jsonFilePath = "Data.json";
        string jsonString = string.Empty;
        try
        {
            jsonString = File.ReadAllText(jsonFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the JSON file: {ex.Message}");
        }


        //options to read

        var options = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
        };

        var roomData = JsonSerializer.Deserialize<RoomData>(jsonString, options);

        ReservationHandler reservationHandler = new ReservationHandler(7, 24); // call constructor with 7 days 24 hours

        if (roomData?.Rooms != null) //  check roomdata is not null
        {
            // create reservations
            Room room1 = roomData.Rooms[0];
            Reservation reservation1 = new Reservation();
            CreateReservation(2024, 4, 5, 10, "Muslera", reservation1, room1);
            reservationHandler.addReservation(reservation1);


            Room room2 = roomData.Rooms[1];
            Reservation reservation2 = new Reservation();
            CreateReservation(2024, 4, 5, 12, "Ziyech", reservation2, room2);
            reservationHandler.addReservation(reservation2);


            Room room3 = roomData.Rooms[2];
            Reservation reservation3 = new Reservation();
            CreateReservation(2024, 4, 5, 14, "Mertens", reservation3, room3);
            reservationHandler.addReservation(reservation3);


            Room room4 = roomData.Rooms[3];
            Reservation reservation4 = new Reservation();
            CreateReservation(2024, 4, 6, 13, "Torreira", reservation4, room4);
            reservationHandler.addReservation(reservation4);


            Room room5 = roomData.Rooms[4];
            Reservation reservation5 = new Reservation();
            CreateReservation(2024, 4, 6, 21, "Kerem", reservation5, room5);
            reservationHandler.addReservation(reservation5);

            reservationHandler.displayWeeklySchedule();
            reservationHandler.deleteReservation(reservation3);
            reservationHandler.deleteReservation(reservation5);

            Room room6 = roomData.Rooms[5];
            Reservation reservation6 = new Reservation();
            CreateReservation(2024, 4, 7, 10, "Icardi", reservation6, room6);
            reservationHandler.addReservation(reservation6);


            reservationHandler.displayWeeklySchedule();
        }




    }
}