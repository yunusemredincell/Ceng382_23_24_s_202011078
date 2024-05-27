using System;
using System.Collections.Generic;

public class Room
{
public int Id { get; set; }
public string ?RoomName { get; set; }
public int Capacity { get; set; }

public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}