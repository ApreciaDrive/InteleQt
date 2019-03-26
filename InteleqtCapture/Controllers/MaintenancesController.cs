using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteleqtCapture.Data;
using InteleqtCapture.Models;

namespace InteleqtCapture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        private readonly CustomerContext _context;

        public MaintenancesController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/Maintenances
        [HttpGet]
        public IEnumerable<Maintenance> Getmaintenances()
        {
            return _context.maintenances;
        }

        // GET: api/Maintenances/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaintenance([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maintenance = await _context.maintenances.FindAsync(id);

            if (maintenance == null)
            {
                return NotFound();
            }

            return Ok(maintenance);
        }

        // PUT: api/Maintenances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenance([FromRoute] string id, [FromBody] Maintenance maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintenance.EntityId)
            {
                return BadRequest();
            }

            _context.Entry(maintenance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceExists(id))
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

        // POST: api/Maintenances
        [HttpPost]
        public async Task<IActionResult> PostMaintenance([FromBody] Maintenance maintenance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.maintenances.Add(maintenance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaintenance", new { id = maintenance.EntityId }, maintenance);
        }

        // DELETE: api/Maintenances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenance([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var maintenance = await _context.maintenances.FindAsync(id);
            if (maintenance == null)
            {
                return NotFound();
            }

            _context.maintenances.Remove(maintenance);
            await _context.SaveChangesAsync();

            return Ok(maintenance);
        }

        private bool MaintenanceExists(string id)
        {
            return _context.maintenances.Any(e => e.EntityId == id);
        }
    }
}