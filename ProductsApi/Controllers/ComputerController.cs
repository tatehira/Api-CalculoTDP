using Mapster;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerComponents>> GetComputer(int id)
        {
            ComputerComponents aComputer = await _context.Computers.FindAsync(id);

            if (aComputer == null)
                return NotFound();

            return Ok(aComputer);
        }

        [HttpPost]
        [Route("ComputersCreate")]
        public async Task<IActionResult> CreateComputer(ComputerComponents computerComponents)
        {
            try
            {
                foreach (var component in CompomentData.ComponentTdpList)
                {
                    
                }

                computerComponents.TdpTotal = Calculo(computerComponents);

                await _context.Computers.AddAsync(computerComponents);
                await _context.SaveChangesAsync();

                return Ok(computerComponents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no processamento: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("ComputerUpdate")]
        public async Task<ActionResult> UpdateComputer(ComputerComponents computerComponents)
        {
            ComputerComponents dbComputer = await _context.Computers.FindAsync(computerComponents.Id);

            if (dbComputer == null)
                return NotFound();

            dbComputer.Adapt(computerComponents);

            await _context.SaveChangesAsync();

            return Ok(computerComponents);
        }

        [HttpDelete]
        [Route("ComputerDelete")]
        public async Task<ActionResult> DeleteComputer(int id)
        {
            ComputerComponents dbComputer = await _context.Computers.FindAsync(id);

            if (dbComputer == null)
                return NotFound();

            _context.Computers.Remove(dbComputer);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("ProcessorsTdp")]
        public ActionResult<ComputerComponents> GetProcessador(string cpu)
        {
            ComputerComponents processor = CompomentData.ComponentTdpList
                .FirstOrDefault(p => p.Cpu.Equals(cpu, StringComparison.OrdinalIgnoreCase));

            var processorInfo = new ComputerComponents { Cpu = processor?.Cpu, TdpCpu = processor?.TdpCpu ?? 0 };

            return Ok(processorInfo);
        }

        private int Calculo(ComputerComponents computerComponents)
        {
            int totalTdp = computerComponents.TdpCpu + computerComponents.TdpGpu;

            switch (computerComponents.SSD)
            {
                case "Default":
                    totalTdp += computerComponents.TdpDefault;
                    break;
                case "Sata":
                    totalTdp += computerComponents.TdpSSDSata;
                    break;
                case "NVME":
                    totalTdp += computerComponents.TdpSSDNvme;
                    break;
            }

            switch (computerComponents.HDD)
            {
                case "Default":
                    totalTdp += computerComponents.TdpDefault;
                    break;
                case "HDD Desktop":
                    totalTdp += computerComponents.TdpHDDPC;
                    break;
                case "HDD Notebook":
                    totalTdp += computerComponents.TdpHDDNote;
                    break;
            }

            switch (computerComponents.Motherboard)
            {
                case "Default":
                    totalTdp += computerComponents.TdpDefault;
                    break;
                case "Micro ATX":
                    totalTdp += computerComponents.TdpMotherboardMicro;
                    break;
                case "Mini ATX":
                    totalTdp += computerComponents.TdpMotherboardMini;
                    break;
                case "ATX":
                    totalTdp += computerComponents.TdpMotherboardATX;
                    break;
                case "Externded":
                    totalTdp += computerComponents.TdpMotherboardExtended;
                    break;
            }

            switch (computerComponents.Ram)
            {
                case "Default":
                    totalTdp += computerComponents.TdpDefault;
                    break;  
                case "Single Channel":
                    totalTdp += computerComponents.TdpRamSingles;
                    break;
                case "Dual Channel":
                    totalTdp += computerComponents.TdpRamDual;
                    break;
                case "Tri Channel":
                    totalTdp += computerComponents.TdpRamTri;
                    break;
                case "Quad Channel":
                    totalTdp += computerComponents.TdpRamQuad;
                    break;
            }

            return totalTdp;
        }
    }
}
