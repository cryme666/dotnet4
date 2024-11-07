using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// using UniversityApp.Data;
using UniversityApp.Models;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Positions
{
    public class DeleteModel : PageModel
    {
        private readonly UniversityContext _context;

        public DeleteModel(UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Position = await _context.Position.FindAsync(id);

            if (Position == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Position = await _context.Position.FindAsync(id);

            if (Position != null)
            {
                _context.Position.Remove(Position);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
