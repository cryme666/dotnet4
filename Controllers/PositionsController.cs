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
public class PositionsController : ControllerBase
{
    private readonly UniversityContext _context;

    public PositionsController(UniversityContext context)
    {
        _context = context;
    }

    // GET: api/Positions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
    {
        return await _context.Position.ToListAsync();
    }

    // GET: api/Positions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Position>> GetPosition(int id)
    {
        var position = await _context.Position.FindAsync(id);

        if (position == null)
        {
            return NotFound();
        }

        return position;
    }

    // POST: api/Positions
    [HttpPost]
    public async Task<ActionResult<Position>> PostPosition(Position position)
    {
        _context.Position.Add(position);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPosition", new { id = position.PositionID }, position);
    }

    // PUT: api/Positions/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPosition(int id, Position position)
    {
        if (id != position.PositionID)
        {
            return BadRequest();
        }

        _context.Entry(position).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Position.Any(e => e.PositionID == id))
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

    // DELETE: api/Positions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePosition(int id)
    {
        var position = await _context.Position.FindAsync(id);
        if (position == null)
        {
            return NotFound();
        }

        _context.Position.Remove(position);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
