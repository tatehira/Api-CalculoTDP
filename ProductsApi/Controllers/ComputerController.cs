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
        #region CRUD
        private readonly ComputerContext _context;
        public ComputerController(ComputerContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //[Route("api/computer/{id}")]
        //public async Task<ActionResult<ComputerComponents>> GetComputer(int id)
        //{
        //    ComputerComponents aComputer = await _context.Computers.FindAsync(id);

        //    if (aComputer == null)
        //        return NotFound();

        //    return Ok(aComputer);
        //}

        [HttpPost]
        [Route("api/computers")]
        public async Task<IActionResult> CreateComputer(ComputerComponents computerComponents)
        {
            int calculatedTdp = CalculateTDP(computerComponents);
            computerComponents.TdpTotal = calculatedTdp;

            await Validation(computerComponents);

            await _context.Computers.AddAsync(computerComponents);

            await _context.SaveChangesAsync();

            return Ok(computerComponents);
        }

        [HttpPut]
        [Route("api/computer")]
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
        [Route("api/computer")]
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
        private Task<IActionResult> Validation(ComputerComponents computerComponents)
        {
            if (computerComponents.Cpu == null)
                return Task.FromResult<IActionResult>(BadRequest("O processador é obrigatório! "));

            return Task.FromResult<IActionResult>(Ok());
        }
        #endregion Validation
    }
}
