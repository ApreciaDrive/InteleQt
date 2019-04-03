using InteleqtCapture.Data;
using InteleqtCapture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteleqtCapture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class AnnuitiesController : ControllerBase
    {
        private readonly CustomerContext _context;

        public AnnuitiesController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/Annuities
        [HttpGet]
        public IEnumerable<Annuity> Getannuities()
        {
            return _context.annuities;
        }

        // GET: api/Annuities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnuity([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var annuity = await _context.annuities.FindAsync(id);

            if (annuity == null)
            {
                return NotFound();
            }

            return Ok(annuity);
        }

        // PUT: api/Annuities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnuity([FromRoute] string id, [FromBody] Annuity annuity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != annuity.EntityId)
            {
                return BadRequest();
            }

            _context.Entry(annuity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnuityExists(id))
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

        // POST: api/Annuities
        [HttpPost]
        public async Task<IActionResult> PostAnnuity([FromBody] Annuity annuity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.annuities.Add(annuity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnnuity", new { id = annuity.EntityId }, annuity);
        }

        // DELETE: api/Annuities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnuity([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var annuity = await _context.annuities.FindAsync(id);
            if (annuity == null)
            {
                return NotFound();
            }

            _context.annuities.Remove(annuity);
            await _context.SaveChangesAsync();

            return Ok(annuity);
        }

        private bool AnnuityExists(string id)
        {
            return _context.annuities.Any(e => e.EntityId == id);
        }
    }
}