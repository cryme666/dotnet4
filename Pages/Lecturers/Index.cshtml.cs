using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
// using UniversityApp.Data; 
using UniversityApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Lecturers
{
    public class IndexModel : PageModel
    {
        private readonly UniversityContext _context;

        public IndexModel(UniversityContext context)
        {
            _context = context;
        }

        public IList<Lecturer> Lecturers { get; set; }

        public async Task OnGetAsync()
        {
            Lecturers = await _context.Lecturer.ToListAsync();
        }
    }
}
