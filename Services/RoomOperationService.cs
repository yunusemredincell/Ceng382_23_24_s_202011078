using MyApp.Namespace;

public class RoomService
{
    private readonly AppDbContext a_context;
    public List<Room> RoomList { get; set; } = default!;
    public RoomService(AppDbContext context){
            this.a_context=context;
    }
    public void AddRooms(Room room){
        a_context.Add(room);
        a_context.SaveChanges();
    }
     public List<Room>GetRooms(){
        return a_context.Rooms.ToList<Room>();
    }

}