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
    public class ComponentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComponentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listComponents")]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents(int machineId)
        {
            var components = await _context.Components
                .Where(c => c.MachineId == machineId)
                .ToListAsync();

            return components;
        }

        [HttpGet("detailComponent/{id}")]
        public async Task<ActionResult<Component>> GetComponent(int machineId, int id)
        {
            var component = await _context.Components
                .FirstOrDefaultAsync(c => c.MachineId == machineId && c.Id == id);

            if (component == null) return NotFound();
            return component;
        }

        [HttpPost("createMachine")]
        public async Task<ActionResult<Component>> CreateComponent(int machineId, [FromBody] ComponentDTO dto)
        {
            var machine = await _context.Machines.FindAsync(machineId);
            if (machine == null) return NotFound("Machine not found.");

            var component = new Component
            {
                MachineId = machineId,
                Part = dto.Part,
                ComponentType = dto.ComponentType,
                BrandName = dto.BrandName,
                Model = dto.Model,
                Description = dto.Description,
                SerialNumber = dto.SerialNumber
            };

            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComponent), new { machineId = machineId, id = component.Id }, component);
        }

        [HttpPut("updateMachine/{id}")]
        public async Task<IActionResult> UpdateComponent(int machineId, int id, [FromBody] ComponentDTO                   dto)
        {
            var component = await _context.Components
                .FirstOrDefaultAsync(c => c.MachineId == machineId && c.Id == id);

            if (component == null) return NotFound();

            component.Part = dto.Part;
            component.ComponentType = dto.ComponentType;
            component.BrandName = dto.BrandName;
            component.Model = dto.Model;
            component.Description = dto.Description;
            component.SerialNumber = dto.SerialNumber;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("deleteMachine/{id}")]
        public async Task<IActionResult> DeleteComponent(int machineId, int id)
        {
            var component = await _context.Components
                .FirstOrDefaultAsync(c => c.MachineId == machineId && c.Id == id);

            if (component == null) return NotFound();

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
