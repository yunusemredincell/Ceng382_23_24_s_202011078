using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Room
{
public int Id { get; set; }
public string ?RoomName { get; set; }

public int Capacity { get; set; }

public string? ImagePath { get; set; }
public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}