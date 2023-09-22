using NotesAppPr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotesAppPr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NotesDbContext _dbContext;

        public NotesController(NotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            var notes = await _dbContext.Notes.ToListAsync();
            return Ok(notes);
        }

        // GET: api/notes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _dbContext.Notes.FindAsync(id);

            if (note == null)
                return NotFound();

            return Ok(note);
        }

        // POST: api/notes
        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote(Note note)
        {
            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNote), new { id = note.Id }, note);
        }

        // PUT: api/notes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, Note note)
        {
            if (id != note.Id)
                return BadRequest();

            _dbContext.Entry(note).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                    return NotFound();
                else
                    throw;
            }
          
            return NoContent();
        }
        

        // DELETE: api/notes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _dbContext.Notes.FindAsync(id);

            if (note == null)
                return NotFound();

            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteExists(int id)
        {
            return _dbContext.Notes.Any(e => e.Id == id);
        }
    }
}