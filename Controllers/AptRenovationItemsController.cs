using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InterfaceToCollection.Model;

namespace InterfaceToCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AptRenovationItemsController : ControllerBase
    {
        private readonly CustomcollectionContext _context;

        public AptRenovationItemsController(CustomcollectionContext context)
        {
            _context = context;
        }

        // GET: api/AptRenovationItems
        [HttpGet]
        public IEnumerable<AptRenovationItem> GetAptRenovationItem([FromQuery(Name="name")] string name)
        {
            if (name != null && name != string.Empty)
                return _context.AptRenovationItem.Where(x => x.Name.Contains(name));
            else
                return _context.AptRenovationItem;
        }

        // GET: api/AptRenovationItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAptRenovationItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aptRenovationItem = await _context.AptRenovationItem.FindAsync(id);

            if (aptRenovationItem == null)
            {
                return NotFound();
            }

            return Ok(aptRenovationItem);
        }

        // PUT: api/AptRenovationItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAptRenovationItem([FromRoute] int id, [FromBody] AptRenovationItem aptRenovationItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aptRenovationItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(aptRenovationItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AptRenovationItemExists(id))
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

        // POST: api/AptRenovationItems
        [HttpPost]
        public async Task<IActionResult> PostAptRenovationItem([FromBody] AptRenovationItem aptRenovationItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AptRenovationItem.Add(aptRenovationItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAptRenovationItem", new { id = aptRenovationItem.Id }, aptRenovationItem);
        }

        // DELETE: api/AptRenovationItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAptRenovationItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var aptRenovationItem = await _context.AptRenovationItem.FindAsync(id);
            if (aptRenovationItem == null)
            {
                return NotFound();
            }

            _context.AptRenovationItem.Remove(aptRenovationItem);
            await _context.SaveChangesAsync();

            return Ok(aptRenovationItem);
        }

        private bool AptRenovationItemExists(int id)
        {
            return _context.AptRenovationItem.Any(e => e.Id == id);
        }
    }
}