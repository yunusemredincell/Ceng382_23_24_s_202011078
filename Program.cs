using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ceng382_23_24_s_202011078;
class Program
{
    static void Main(string[] args)
    {
        //path to json
        // todo inside try catch
        string jsonFilePath = "Data.json";
        string jsonString = File.ReadAllText(jsonFilePath);

        //options to read

        var options = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
        };

        var roomData = JsonSerializer.Deserialize<RoomData>(jsonString, options);

        if (roomData?.Rooms != null)
        {
            foreach (var room in roomData.Rooms)
            {
                Console.WriteLine($"Room ID: {room.roomId}, Name: {room.roomName}, Capacity: {room.capacity}");
            }
        }
    }
}