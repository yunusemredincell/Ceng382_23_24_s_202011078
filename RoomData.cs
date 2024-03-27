using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ceng382_23_24_s_202011078;


public class RoomData
{
    [JsonPropertyName("Room")]
    public Room[]? Rooms { get; set; }
}