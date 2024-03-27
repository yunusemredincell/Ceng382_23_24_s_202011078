using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ceng382_23_24_s_202011078;
public class Room
{
    [JsonPropertyName("roomId")]
    public string roomId { get; set; }

    [JsonPropertyName("roomName")]
    public string roomName { get; set; }

    [JsonPropertyName("capacity")]
    public int capacity { get; set; }
}