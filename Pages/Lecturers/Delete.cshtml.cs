using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// using UniversityApp.Data;
using UniversityApp.Models;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Lecturers
{
    public class DeleteModel : PageModel
    {
        private readonly UniversityContext _context;

        public DeleteModel(UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lecturer Lecturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Lecturer = await _context.Lecturer.FindAsync(id);

            if (Lecturer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Lecturer = await _context.Lecturer.FindAsync(id);

            if (Lecturer != null)
            {
                _context.Lecturer.Remove(Lecturer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
