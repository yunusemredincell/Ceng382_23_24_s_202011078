using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YedWebApp1.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class ShowReservationModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public ShowReservationModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public ReservationFilter Filter { get; set; }
    public IList<Reservation> Reservations { get; set; }

    public void OnGet()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var query = _context.Reservations
            .Include(r => r.room)
            .Where(r => r.reserverName == userId)
            .AsQueryable();

        if (!string.IsNullOrEmpty(Filter.RoomName))
        {
            query = query.Where(r => r.room.RoomName.Contains(Filter.RoomName));
        }

        if (Filter.StartDate.HasValue && Filter.EndDate.HasValue)
        {
            query = query.Where(r => r.ReservationStartDate >= Filter.StartDate.Value && r.ReservationEndDate <= Filter.EndDate.Value);
        }

        if (Filter.Capacity.HasValue)
        {
            query = query.Where(r => r.room.Capacity == Filter.Capacity.Value);
        }

        Reservations = query.ToList();
    }
}

public class ReservationFilter
{
    public string RoomName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Capacity { get; set; }
}
