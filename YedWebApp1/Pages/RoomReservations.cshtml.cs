using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YedWebApp1.Data;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;

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
        if (!ModelState.IsValid)
        {
            Rooms = _context.Rooms.ToList(); 
            return Page();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Reservation.reserverName = userId;

        bool isRoomAvailable = !_context.Reservations
            .Any(r => r.RoomId == Reservation.RoomId &&
                      r.ReservationEndDate > Reservation.ReservationStartDate);

        if (!isRoomAvailable)
        {
            ModelState.AddModelError(string.Empty, "The selected room is not available for the specified date and time.");
            Rooms = _context.Rooms.ToList(); 

        }

        _context.Reservations.Add(Reservation);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"Reservation created: {Reservation.Id} by {Reservation.reserverName}");

        return RedirectToPage("ShowReservations");
    }
}
