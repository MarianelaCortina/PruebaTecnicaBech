using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBech.Data;
using PruebaTecnicaBech.DTOs;
using PruebaTecnicaBech.Models;


namespace PruebaTecnicaBech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MachineController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listMachines")]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMachines()
        {
            return await _context.Machines
                .Include(m => m.Components)
                .ToListAsync();
        }

        [HttpGet("detailMachine/{id}")]
        public async Task<ActionResult<Machine>> GetMachine(int id)
        {
            var machine = await _context.Machines
                .Include(m => m.Components)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (machine == null)
                return NotFound();
            return machine;
        }

        [HttpPost("createMachine")]
        public async Task<ActionResult<Machine>> CreateMachine([FromBody] MachineDTO dto)
        {
            var machine = new Machine
            {
                TechnicalLocation = dto.TechnicalLocation,
                Description = dto.Description,
                Model = dto.Model,
                SerialNumber = dto.SerialNumber,
                MachineTypeName = dto.MachineTypeName,
                BrandName = dto.BrandName,
                Criticality = dto.Criticality,
                Sector = dto.Sector
            };

            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMachine), new { id = machine.Id }, machine);
        }

        [HttpPut("updateMachine/{id}")]
        public async Task<IActionResult> UpdateMachine(int id, [FromBody] MachineDTO dto)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null) return NotFound();

            machine.TechnicalLocation = dto.TechnicalLocation;
            machine.Description = dto.Description;
            machine.Model = dto.Model;
            machine.SerialNumber = dto.SerialNumber;
            machine.MachineTypeName = dto.MachineTypeName;
            machine.BrandName = dto.BrandName;
            machine.Criticality = dto.Criticality;
            machine.Sector = dto.Sector;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("deleteMachine/{id}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null) return NotFound();

            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
