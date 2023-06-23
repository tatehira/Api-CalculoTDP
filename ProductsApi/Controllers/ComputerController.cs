using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;
using static ProductsApi.Models.Enums.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        [Route("api/ComputersCreate")]
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
        [Route("api/ComputerUpdate")]
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
        [Route("api/ComputerDelete")]
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
        [Route("Api/ProcessorsTdp")]
        public ActionResult<ComputerComponents> GetProcessador(string cpu)
        {
            ComputerComponents processor = CompomentData.ComponentTdpList
                .FirstOrDefault(p => p.Cpu.Equals(cpu, StringComparison.OrdinalIgnoreCase));

            var processorInfo = new ComputerComponents { Cpu = processor?.Cpu, TdpCpu = processor?.TdpCpu ?? 0 };

            return Ok(processorInfo);
        }

        [HttpGet]
        [Route("Api/PlacaVideoTdp")]
        public ActionResult<ComputerComponents> GetVideoCard(string gpu)
        {
            ComputerComponents videocard = CompomentData.ComponentTdpList.FirstOrDefault(p => p.Gpu.Equals(gpu, StringComparison.OrdinalIgnoreCase));

            var GPUInfo = new ComputerComponents { Gpu = videocard?.Cpu, TdpGpu = videocard?.TdpCpu ?? 0 };

            return Ok(GPUInfo);
        }

        [HttpGet]
        [Route("Api/MotherboardTdp")]
        public ActionResult<int> GetMotherboardTdp(string motherboard)
        {
            MotherboardEnum selectMotherboard = Enum.Parse<MotherboardEnum>(motherboard);

            ComputerComponents motherboardInfo = CompomentData.ComponentTdpList.FirstOrDefault(m => m.Motherboard == selectMotherboard);

            return Ok(motherboardInfo?.TdpTotal ?? 0);
        }

        private int Calculo(ComputerComponents computerComponents)
        {
            int totalTdp = computerComponents.TdpCpu + computerComponents.TdpGpu;

            switch (computerComponents.SSD)
            {
                case SSDType.Sata:
                    totalTdp += computerComponents.TdpSSDSata;
                    break;
                case SSDType.Nvme:
                    totalTdp += computerComponents.TdpSSDNvme;
                    break;
            }

            switch (computerComponents.HDD)
            {
                case HDDType.HDDDesktop:
                    totalTdp += computerComponents.TdpHDDPC;
                    break;
                case HDDType.HDDNotebook:
                    totalTdp += computerComponents.TdpHDDNote;
                    break;
            }

            switch (computerComponents.Motherboard)
            {
                case MotherboardEnum.MicroATX:
                    totalTdp += computerComponents.TdpMotherboardMicro;
                    break;
                case MotherboardEnum.MiniATX:
                    totalTdp += computerComponents.TdpMotherboardMini;
                    break;
                case MotherboardEnum.ATX:
                    totalTdp += computerComponents.TdpMotherboardATX;
                    break;
                case MotherboardEnum.ExtendedATX:
                    totalTdp += computerComponents.TdpMotherboardExtended;
                    break;
            }

            switch (computerComponents.Ram)
            {
                case RamEnum.Single:
                    totalTdp += computerComponents.TdpRamSingles;
                    break;
                case RamEnum.Dual:
                    totalTdp += computerComponents.TdpRamDual;
                    break;
                case RamEnum.Tri:
                    totalTdp += computerComponents.TdpRamTri;
                    break;
                case RamEnum.Quad:
                    totalTdp += computerComponents.TdpRamQuad;
                    break;
            }

            return totalTdp;
        }
    }
}
