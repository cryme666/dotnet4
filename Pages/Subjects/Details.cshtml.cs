using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
// using UniversityApp.Data; // Make sure this namespace matches your project structure
using UniversityApp.Models; // Ensure this is the correct namespace for your models

namespace UniversityApp.Pages.Subjects
{
    public class DetailsModel : PageModel
    {
        private readonly UniversityContext _context;

        public DetailsModel(UniversityContext context)
        {
            _context = context;
        }

        public Subject Subject { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Subject = await _context.Subject.FirstOrDefaultAsync(m => m.SubjectID == id);

            if (Subject == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
