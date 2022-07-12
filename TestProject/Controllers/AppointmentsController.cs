using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Appointments.Data;
using Appointments.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentsContext _context;

        public AppointmentsController(AppointmentsContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MrAppointment>>> GetMrAppointments()
        {
          if (_context.MrAppointments == null)
          {
              return NotFound();
          }
            return await _context.MrAppointments.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MrAppointment>> GetMrAppointment(int id)
        {
          if (_context.MrAppointments == null)
          {
              return NotFound();
          }
            var mrAppointment = await _context.MrAppointments.FindAsync(id);

            if (mrAppointment == null)
            {
                return NotFound();
            }

            return mrAppointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMrAppointment(int id, MrAppointment mrAppointment)
        {
            if (id != mrAppointment.Id)
            {
                return BadRequest();
            }

            _context.Entry(mrAppointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MrAppointmentExists(id))
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

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MrAppointment>> PostMrAppointment(MrAppointment mrAppointment)
        {
          if (_context.MrAppointments == null)
          {
              return Problem("Entity set 'AppointmentsContext.MrAppointments'  is null.");
          }
            _context.MrAppointments.Add(mrAppointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMrAppointment", new { id = mrAppointment.Id }, mrAppointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMrAppointment(int id)
        {
            if (_context.MrAppointments == null)
            {
                return NotFound();
            }
            var mrAppointment = await _context.MrAppointments.FindAsync(id);
            if (mrAppointment == null)
            {
                return NotFound();
            }

            _context.MrAppointments.Remove(mrAppointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MrAppointmentExists(int id)
        {
            return (_context.MrAppointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
