using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YedWebApp1.Data;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

[Authorize]
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

    public async Task<IActionResult> OnPostAsync()
    {
        _logger.LogInformation("OnPostAsync called with Reservation: {@Reservation}", Reservation);

        if (!ModelState.IsValid)
        {
            Rooms = _context.Rooms.ToList();
            _logger.LogWarning("Model state is invalid. Returning to the page.");
            return Page();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Reservation.reserverName = userId;

        if (Reservation.ReservationStartDate >= Reservation.ReservationEndDate)
        {
            ModelState.AddModelError(string.Empty, "The start date must be before the end date.");
            Rooms = _context.Rooms.ToList();
            _logger.LogWarning("Invalid date range: StartDate={StartDate}, EndDate={EndDate}", Reservation.ReservationStartDate, Reservation.ReservationEndDate);
            return Page();
        }

        bool isRoomAvailable = !_context.Reservations
            .Any(r => r.RoomId == Reservation.RoomId &&
                      r.ReservationStartDate < Reservation.ReservationEndDate &&
                      r.ReservationEndDate > Reservation.ReservationStartDate);

        _logger.LogInformation("Room availability check: RoomId={RoomId}, StartDate={StartDate}, EndDate={EndDate}, IsAvailable={IsAvailable}",
            Reservation.RoomId, Reservation.ReservationStartDate, Reservation.ReservationEndDate, isRoomAvailable);

        if (!isRoomAvailable)
        {
            ModelState.AddModelError(string.Empty, "The selected room is not available for the specified date and time.");
            Rooms = _context.Rooms.ToList();
            _logger.LogWarning("Room not available for the specified date and time.");
            return Page();
        }

        _context.Reservations.Add(Reservation);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Reservation created: {Reservation.Id} by {Reservation.reserverName}");

        return RedirectToPage("ShowReservations");
    }
}
