using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
// using UniversityApp.Data;
using UniversityApp.Models;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Lecturers
{
    public class EditModel : PageModel
    {
        private readonly UniversityContext _context;

        public EditModel(UniversityContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
            //     return Page();
            // }

            _context.Attach(Lecturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Lecturer.Any(e => e.LecturerID == Lecturer.LecturerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }
    }
}
