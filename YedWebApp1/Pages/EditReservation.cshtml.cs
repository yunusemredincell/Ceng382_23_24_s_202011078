using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YedWebApp1.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

public class EditReservationModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditReservationModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Reservation Reservation { get; set; }
    public IList<Room> Rooms { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Reservation = await _context.Reservations.FindAsync(id);
        if (Reservation == null)
        {
            return NotFound();
        }

        Rooms = await _context.Rooms.ToListAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Rooms = await _context.Rooms.ToListAsync();
            return Page();
        }

        _context.Attach(Reservation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Reservations.Any(e => e.Id == Reservation.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("ShowReservation");
    }
}
