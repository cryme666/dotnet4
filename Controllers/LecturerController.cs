using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;

[Route("api/[controller]")]
[ApiController]
public class LecturerController : ControllerBase
{
    private readonly UniversityContext _context;

    public LecturerController(UniversityContext context)
    {
        _context = context;
    }

    // GET: api/Lecturer
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lecturer>>> GetLecturers()
    {
        var lecturers = await _context.Lecturer
            .Include(l => l.LecturerSubjects)
            .ThenInclude(ls => ls.Subject)
            .ToListAsync();

        // Налаштування опцій серіалізації
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        // Серіалізація результату з використанням опцій
        var jsonString = JsonSerializer.Serialize(lecturers, options);
        return Content(jsonString, "application/json");
    }

    // GET: api/Lecturer/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Lecturer>> GetLecturer(int id)
    {
        var lecturer = await _context.Lecturer
            .Include(l => l.LecturerSubjects)
            .ThenInclude(ls => ls.Subject)
            .FirstOrDefaultAsync(l => l.LecturerID == id);

        if (lecturer == null)
        {
            return NotFound();
        }

        // Налаштування опцій серіалізації
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        // Серіалізація результату з використанням опцій
        var jsonString = JsonSerializer.Serialize(lecturer, options);
        return Content(jsonString, "application/json");
    }

    // POST: api/Lecturer
    [HttpPost]
    public async Task<ActionResult<Lecturer>> PostLecturer(Lecturer lecturer)
    {
        _context.Lecturer.Add(lecturer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLecturer), new { id = lecturer.LecturerID }, lecturer);
    }

    // PUT: api/Lecturer/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLecturer(int id, Lecturer lecturer)
    {
        if (id != lecturer.LecturerID)
        {
            return BadRequest();
        }

        _context.Entry(lecturer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Lecturer.Any(e => e.LecturerID == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Lecturer/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLecturer(int id)
    {
        var lecturer = await _context.Lecturer.FindAsync(id);
        if (lecturer == null)
        {
            return NotFound();
        }

        _context.Lecturer.Remove(lecturer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
