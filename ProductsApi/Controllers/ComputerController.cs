using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly ComputerContext _context;
        public ComputerController(ComputerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/computer")]
        public async Task<ActionResult> GetComputer()
        {
            return Ok(await _context.Computers.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateComputer(ComputerComponents computerComponents)
        {
            await _context.Computers.AddAsync(computerComponents);

            await _context.SaveChangesAsync();

            return Ok(computerComponents);
        }

        [HttpPut]
        [Route("/computer")]
        public async Task<ActionResult> UpdateComputer(ComputerComponents computerComponents)
        {
            var dbComputer = await _context.Computers.FindAsync(computerComponents.Id);

            if (dbComputer == null)
                return NotFound();

            dbComputer.Cpu = computerComponents.Cpu;
            dbComputer.TdpCpu = computerComponents.TdpCpu;
            dbComputer.Gpu = computerComponents.Gpu;
            dbComputer.TdpGpu = computerComponents.TdpGpu;
            dbComputer.Motherboard = computerComponents.Motherboard;
            dbComputer.TdpMotherboard = computerComponents.TdpMotherboard;
            dbComputer.Ram = computerComponents.Ram;
            dbComputer.TdpRam = computerComponents.TdpRam;
            dbComputer.QntRam = computerComponents.QntRam;
            dbComputer.SSD = computerComponents.SSD;
            dbComputer.TdpSSD = computerComponents.TdpSSD;
            dbComputer.HDD = computerComponents.HDD;
            dbComputer.TdpHDD = computerComponents.TdpHDD;

            await _context.SaveChangesAsync();

            return Ok(computerComponents);
        }

        [HttpDelete]
        [Route("/computer")]
        public async Task<ActionResult> UpdateComputer(Guid id)
        {
            var dbComputer = await _context.Computers.FindAsync(id);

            if (dbComputer == null)
                return NotFound();

            _context.Computers.Remove(dbComputer);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
