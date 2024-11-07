using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
// using UniversityApp.Data; 
using UniversityApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityApp.Pages.Positions
{
    public class IndexModel : PageModel
    {
        private readonly UniversityContext _context;

        public IndexModel(UniversityContext context)
        {
            _context = context;
        }

        public IList<Position> Positions { get; set; }

        public async Task OnGetAsync()
        {
            Positions = await _context.Position.ToListAsync();
        }
    }
}
