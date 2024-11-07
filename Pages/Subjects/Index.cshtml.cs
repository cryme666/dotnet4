using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
// using UniversityApp.Data; 
using UniversityApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly UniversityContext _context;

        public IndexModel(UniversityContext context)
        {
            _context = context;
        }

        public IList<Subject> Subjects { get; set; }

        public async Task OnGetAsync()
        {
            Subjects = await _context.Subject.ToListAsync();
        }
    }
}
