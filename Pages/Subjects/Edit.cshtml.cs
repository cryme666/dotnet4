using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
// using UniversityApp.Data;
using UniversityApp.Models;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly UniversityContext _context;

        public EditModel(UniversityContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
            //     return Page();
            // }

            _context.Attach(Subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Subject.Any(e => e.SubjectID == Subject.SubjectID))
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
