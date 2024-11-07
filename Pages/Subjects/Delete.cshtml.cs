using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// using UniversityApp.Data;
using UniversityApp.Models;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Subjects
{
    public class DeleteModel : PageModel
    {
        private readonly UniversityContext _context;

        public DeleteModel(UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await _context.Subject.FindAsync(id);

            if (Subject == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Subject = await _context.Subject.FindAsync(id);

            if (Subject != null)
            {
                _context.Subject.Remove(Subject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
