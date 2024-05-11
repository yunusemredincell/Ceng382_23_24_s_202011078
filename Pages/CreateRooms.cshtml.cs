using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class CreateRoomsModel : PageModel
    {

         [BindProperty]
                    
        public Room Room { get; set; }
        RoomService roomService;
        
        public CreateRoomsModel(AppDbContext context)
        {
            this.roomService = new RoomService(context);

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Room == null)
            {
                return Page();
            }
            roomService.AddRooms(Room);
            return RedirectToAction("Get");
        }




        public void OnGet()
        {
        }
    }
}
