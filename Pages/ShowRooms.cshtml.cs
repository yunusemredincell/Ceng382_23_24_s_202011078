using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class ShowRoomsModel : PageModel
    {
          RoomService roomService;
        
        private readonly AppDbContext show_context;
        public ShowRoomsModel(AppDbContext context){
          this.roomService = new RoomService(context);

        }
        public List<Room>RoomList { get; set; }=default!;
        public void OnGet()
        {
              RoomList=roomService.GetRooms();
        }
    }
}
