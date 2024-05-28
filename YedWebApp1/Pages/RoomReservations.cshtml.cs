using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YedWebApp1.Data;
using System.Security.Claims;

public class RoomReservationModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RoomReservationModel> _logger;

    public RoomReservationModel(ApplicationDbContext context, ILogger<RoomReservationModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    [BindProperty]
    public Reservation Reservation { get; set; }
    public IList<Room> Rooms { get; set; }

    public void OnGet()
    {
        Rooms = _context.Rooms.ToList();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Reservation.reserverName = userId;
        _context.Reservations.Add(Reservation);
        _context.SaveChanges();

        _logger.LogInformation($"Reservation created: {Reservation.Id} by {Reservation.reserverName}");

        return RedirectToPage("./ShowReservations");
    }
}
