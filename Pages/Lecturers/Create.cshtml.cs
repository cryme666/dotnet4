using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// using UniversityApp.Data;
using UniversityApp.Models;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Lecturers
{
    public class CreateModel : PageModel
    {
        private readonly UniversityContext _context;

        public CreateModel(UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lecturer Lecturer { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
            //     return Page();
            // }

            _context.Lecturer.Add(Lecturer);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}