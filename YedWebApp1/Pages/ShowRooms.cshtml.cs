using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YedWebApp1.Data;

namespace MyApp.Namespace
{

  [Authorize]
  public class ShowRoomsModel : PageModel
  {
    RoomService roomService;

    private readonly ApplicationDbContext show_context;
    public ShowRoomsModel(ApplicationDbContext context) => roomService = new RoomService(context);
    public List<Room> RoomList { get; set; } = default!;
    public void OnGet()
    {
      RoomList = roomService.GetRooms();
    }
  }

}
