using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YedWebApp1.Data;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Namespace
{
    public class ShowRoomsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ShowRoomsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Room> RoomList { get; set; }

        public void OnGet()
        {
            RoomList = _context.Rooms.ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var room = _context.Rooms.Find(id);

            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }

            return RedirectToPage();
        }
    }
}
