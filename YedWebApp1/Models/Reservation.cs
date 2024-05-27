public class Reservation
{
    public int Id { get; set; }
    public int RoomId {get;set;}
    public DateTime ReservationEndDate { get; set; }
    public DateTime ReservationStartDate { get; set; }
    public string? reserverName { get; set; }
    public Room? room { get; set; }
}