


using Microsoft.EntityFrameworkCore;

namespace YedWebApp1.Data;
public class RoomService
{
    private readonly MyAppDbContext a_context;
    public List<Room> RoomList { get; set; } = default!;
    public RoomService(MyAppDbContext context){
            this.a_context=context;
    }
    public void AddRooms(Room room){
        a_context.Add(room);
        a_context.SaveChanges();
    }
     public List<Room>GetRooms(){
        return a_context.Rooms.ToList<Room>();
    }
    public void AddReservation(Reservation reservation)
{
    try
    {
        a_context.Reservations.Add(reservation);
        a_context.SaveChanges();
    }
    catch (Exception ex)
    {
        // Consider logging the exception
        Console.WriteLine("An error occurred: " + ex.Message);
        throw; // Rethrow the exception to handle it further up the call stack if necessary.
    }
}
      public List<Reservation>GetReservations(){
        return a_context.Reservations.Include(r=>r.room).ToList();
    }


}