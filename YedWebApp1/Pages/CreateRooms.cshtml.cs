using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using YedWebApp1.Data;

namespace MyApp.Namespace
{
    [Authorize]
    public class CreateRoomsModel : PageModel
    {
        [BindProperty]
        public Room Room { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }  

        private readonly RoomService roomService;

        public CreateRoomsModel(ApplicationDbContext context)
        {
            roomService = new RoomService(context);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Room == null)
            {
                return Page();
            }

            if (Image != null)
            {
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine("wwwroot/image", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                Room.ImagePath = $"/image/{fileName}";
            }

            roomService.AddRooms(Room);
            return RedirectToPage("ShowReservations"); 
        }

        public void OnGet()
        {
        }
    }
}
