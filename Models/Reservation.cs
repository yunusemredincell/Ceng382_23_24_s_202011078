
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ceng382_23_24_s_202011078;
public class Reservation
{
    public DateTime Time { get; set; }
    public DateTime Date { get; set; }
    public string? reserverName { get; set; }
    public Room? room { get; set; }
}