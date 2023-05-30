using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STOlizza.Leto.Server;
using STOlizza.Leto.Shared;

namespace STOlizza.Leto.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnairyDTOesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public QuestionnairyDTOesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/QuestionnairyDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionnairyDTO>>> GetRecords()
        {
          if (_context.Records == null)
          {
              return NotFound();
          }
            return await _context.Records.ToListAsync();
        }

        // GET: api/QuestionnairyDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionnairyDTO>> GetQuestionnairyDTO(int id)
        {
          if (_context.Records == null)
          {
              return NotFound();
          }
            var questionnairyDTO = await _context.Records.FindAsync(id);

            if (questionnairyDTO == null)
            {
                return NotFound();
            }

            return questionnairyDTO;
        }

        // PUT: api/QuestionnairyDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionnairyDTO(int id, QuestionnairyDTO questionnairyDTO)
        {
            if (id != questionnairyDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionnairyDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnairyDTOExists(id))
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

        // POST: api/QuestionnairyDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionnairyDTO>> PostQuestionnairyDTO(QuestionnairyDTO questionnairyDTO)
        {
            Console.Clear();
            Console.WriteLine("Received data");
          if (_context.Records == null)
          {
              return Problem("Entity set 'DatabaseContext.Records'  is null.");
          }
          //if (_context.Records.Count() == 0)
          //  {
          //      _context.Add(new QuestionnairyDTO { Id = 0, Smena = 0, QImage = Array.Empty<byte>()/*, ImagePath = "test"*/, FirstName = "test", LastName = "test", FatherName = "test", BirthDate = DateTime.Today.AddYears(-18), Sex = "test", WorkingPlace = "test", Post = "test", PhoneNumber = "test", VkLink = "test", TelegramUsername = "test", ClothesSize = "test", Allergies = "test", Illneses = "test", KnowledgeSource = "test", DesiredSkills = "test", ExpirienceIntentions = "test", VideoPath = "test" });
          //      await _context.SaveChangesAsync();
          //  }
          //var nextid = _context.Records.OrderByDescending(x => x.Id).Last().Id + 1;
          //  Console.Clear();
          //  Console.WriteLine($"next id is {nextid}");
            _context.Records.Add(questionnairyDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionnairyDTO", new { id = questionnairyDTO.Id }, questionnairyDTO);
        }


        // DELETE: api/QuestionnairyDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionnairyDTO(int id)
        {
            if (_context.Records == null)
            {
                return NotFound();
            }
            var questionnairyDTO = await _context.Records.FindAsync(id);
            if (questionnairyDTO == null)
            {
                return NotFound();
            }

            _context.Records.Remove(questionnairyDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionnairyDTOExists(int id)
        {
            return (_context.Records?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
