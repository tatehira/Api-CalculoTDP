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

        private int Calculo(ComputerComponents computerComponents)
        {
            int totalTdp = GetTdpValue(computerComponents.Cpu) + GetTdpValue(computerComponents.Gpu);

            switch (computerComponents.SSD)
            {
                case "Default":
                    totalTdp += 0;
                    break;
                case "Sata":
                    totalTdp += 3;
                    break;
                case "Nvme":
                    totalTdp += 5;
                    break;
            }

            switch (computerComponents.HDD)
            {
                case "Default":
                    totalTdp += 0;
                    break;
                case "HDD-Desktop":
                    totalTdp += 8;
                    break;
                case "HDD-Notebook":
                    totalTdp += 5;
                    break;
            }

            switch (computerComponents.Motherboard)
            {
                case "Default":
                    totalTdp += 0;
                    break;
                case "Micro-ATX":
                    totalTdp += 8;
                    break;
                case "Mini-ATX":
                    totalTdp += 6;
                    break;
                case "ATX":
                    totalTdp += 10;
                    break;
                case "ExtendedATX":
                    totalTdp += 12;
                    break;
            }

            switch (computerComponents.Ram)
            {
                case "Default":
                    totalTdp += 0;
                    break;
                case "Single-Channel":
                    totalTdp += 8;
                    break;
                case "Dual-Channel":
                    totalTdp += 8;
                    break;
                case "Tri-Channel":
                    totalTdp += 8;
                    break;
                case "Quad-Channel":
                    totalTdp += 8;
                    break;
            }

            return totalTdp;
        }

        private int GetTdpValue(string component)
        {
            switch (component)
            {
                // Processadores Intel
                case "Intel Core i9-11900K":
                case "Intel Core i7-11700K":
                case "Intel Core i5-11600K":
                case "Intel Core i9-10900K":
                case "Intel Core i7-10700K":
                    return 125;
                case "Intel Core i5-10400F":
                case "Intel Core i7-9700K":
                case "Intel Core i9-12900K":
                case "Intel Core i7-12700K":
                case "Intel Core i5-12600K":
                case "Intel Core i9-11900KF":
                case "Intel Core i7-11700KF":
                case "Intel Core i9-10900KF":
                case "Intel Core i7-10700KF":
                case "Intel Core i5-10400":
                case "Intel Core i7-9700KF":
                    return 65;

                // Processadores AMD
                case "AMD Ryzen 9 5950X":
                case "AMD Ryzen 9 5900X":
                case "AMD Ryzen 7 5800X":
                    return 105;
                case "AMD Ryzen 5 5600X":
                case "Intel Core i5-10600K":
                case "Intel Core i9-10850K":
                case "AMD Ryzen 7 3700X":
                    return 65;
                case "AMD Ryzen 5 3600X":
                case "AMD Ryzen 9 5900HX":
                case "AMD Ryzen 7 5800HX":
                case "AMD Ryzen 7 2700X":
                    return 95;

                // Placas de vídeo Nvidia
                case "Nvidia GeForce RTX 3090":
                case "Nvidia GeForce RTX 3080":
                case "Nvidia GeForce RTX 3070":
                    return 350;
                case "Nvidia GeForce RTX 3060 Ti":
                case "Nvidia GeForce RTX 3060":
                case "Nvidia GeForce RTX 2080 Ti":
                case "Nvidia GeForce RTX 2080 Super":
                    return 200;
                case "Nvidia GeForce RTX 2070 Super":
                case "Nvidia GeForce RTX 2060 Super":
                case "Nvidia GeForce GTX 1080 Ti":
                case "Nvidia GeForce GTX 1080":
                case "Nvidia GeForce GTX 1070":
                case "Nvidia GeForce GTX 1060":
                    return 150;

                // Placas de vídeo AMD
                case "AMD Radeon RX 6900 XT":
                case "AMD Radeon RX 6800 XT":
                case "AMD Radeon RX 6800":
                    return 300;
                case "AMD Radeon RX 6700 XT":
                case "AMD Radeon RX 6700":
                    return 230;
                case "AMD Radeon RX 5700 XT":
                case "AMD Radeon RX 5700":
                case "AMD Radeon RX 5600 XT":
                    return 180;

                default:
                    return 0;
            }
        }

    }
}
