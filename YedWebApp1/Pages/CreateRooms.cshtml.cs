using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YedWebApp1.Data;

namespace MyApp.Namespace
{
    [Authorize]
    public class CreateRoomsModel : PageModel
    {

        [BindProperty]

        public Room Room { get; set; }
        RoomService roomService;

        public CreateRoomsModel(MyAppDbContext context)
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
