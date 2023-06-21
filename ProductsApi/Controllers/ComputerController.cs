﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Models;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        #region CRUD
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
                int calculatedTdp = CalculateTDP(computerComponents);
                computerComponents.TdpTotal = calculatedTdp;

                Validation(computerComponents);

                await _context.Computers.AddAsync(computerComponents);

                await _context.SaveChangesAsync();

                return Ok(computerComponents);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro no processamento! ");
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
        #endregion CRUD

        #region Lista de process e TDP

        [HttpGet]
        [Route("Api/ProcessorsTdp")]
        public ActionResult<ComputerComponents> GetProcessador(string cpu)
        {
            ComputerComponents processor = CompomentData.ProcessorTdpList
                                           .FirstOrDefault(p => p.Cpu.Equals (cpu, StringComparison.OrdinalIgnoreCase));

            var processorInfo = new ComputerComponents { Cpu = processor.Cpu, TdpCpu = processor.TdpCpu };

            return processorInfo;
        }


        #endregion Lista de process e TDP

        #region Regas

        private int CalculateTDP(ComputerComponents computerComponents)
        {
            int totalTdp = computerComponents.TdpCpu + computerComponents.TdpGpu +
                           computerComponents.TdpMotherboard + computerComponents.TdpSSD + 
                           computerComponents.TdpHDD + (computerComponents.TdpRam * computerComponents.QntRam);
            return totalTdp;
        }

        #endregion Regas

        #region Validation
        private void Validation(ComputerComponents computerComponents)
        {
            if (computerComponents.Cpu == null)
                throw new ArgumentException("Processador obrigatório! ");
        }
        #endregion Validation
    }
}
