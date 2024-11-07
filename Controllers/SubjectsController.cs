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
public class SubjectsController : ControllerBase
{
    private readonly UniversityContext _context;

    public SubjectsController(UniversityContext context)
    {
        _context = context;
    }

    // GET: api/Subjects
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
    {
        return await _context.Subject.ToListAsync();
    }

    // GET: api/Subjects/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Subject>> GetSubject(int id)
    {
        var subject = await _context.Subject.FindAsync(id);

        if (subject == null)
        {
            return NotFound();
        }

        return subject;
    }

    // POST: api/Subjects
    [HttpPost]
    public async Task<ActionResult<Subject>> PostSubject(Subject subject)
    {
        _context.Subject.Add(subject);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSubject", new { id = subject.SubjectID }, subject);
    }

    // PUT: api/Subjects/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSubject(int id, Subject subject)
    {
        if (id != subject.SubjectID)
        {
            return BadRequest();
        }

        _context.Entry(subject).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Subject.Any(e => e.SubjectID == id))
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

    // DELETE: api/Subjects/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubject(int id)
    {
        var subject = await _context.Subject.FindAsync(id);
        if (subject == null)
        {
            return NotFound();
        }

        _context.Subject.Remove(subject);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
