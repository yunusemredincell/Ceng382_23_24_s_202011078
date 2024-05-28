using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YedWebApp1.Data;
using System.Threading.Tasks;

public class DeleteReservationModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteReservationModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Reservation Reservation { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Reservation = await _context.Reservations.FindAsync(id);
        if (Reservation == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        Reservation = await _context.Reservations.FindAsync(id);

        if (Reservation != null)
        {
            _context.Reservations.Remove(Reservation);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("ShowReservations");
    }
}
