using Microsoft.EntityFrameworkCore;

namespace YedWebApp1.Data
{
    public class RoomService
    {
        private readonly ApplicationDbContext _context;
        public List<Room> RoomList { get; set; } = default!;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddRooms(Room room)
        {
            _context.Add(room);
            _context.SaveChanges();
        }

        public List<Room> GetRooms()
        {
            return _context.Rooms.ToList();
        }

        public void AddReservation(Reservation reservation)
        {
            try
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Consider logging the exception
                Console.WriteLine("An error occurred: " + ex.Message);
                throw; // Rethrow the exception to handle it further up the call stack if necessary.
            }
        }

        public List<Reservation> GetReservations()
        {
            return _context.Reservations.Include(r => r.room).ToList();
        }
    }
}
