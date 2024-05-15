public class Reservation
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public DateTime Date { get; set; }
    public string? reserverName { get; set; }
    public Room? room { get; set; }
}