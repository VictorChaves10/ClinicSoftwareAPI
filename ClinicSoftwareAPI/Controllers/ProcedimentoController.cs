using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSoftwareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimentoController : ControllerBase
    {
        private readonly IProcedimentoService _procedimentoService;

        public ProcedimentoController(IProcedimentoService procedimentoService)
        {
            _procedimentoService = procedimentoService;
        }

        // GET: api/Procedimento
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var procedimentos = await _procedimentoService.GetProcedimentos();

            if (!procedimentos.Any())
                return NotFound("Nenhum procedimento encontrado.");

            return Ok(procedimentos);
        }

        // GET: api/Procedimento/{id}
        [HttpGet("{id:long}", Name = "ObterProcedimento")]
        public async Task<IActionResult> GetById(long id)
        {
            var procedimento = await _procedimentoService.GetProcedimentoById(id);

            return procedimento == null
                ? NotFound($"Procedimento não encontrado.")
                : Ok(procedimento);
        }

        // PUT: api/Procedimento/{id}
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProcedimentoDto procedimentoDto)
        {
            if (procedimentoDto == null)
                return BadRequest("Dados inválidos.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _procedimentoService.Add(procedimentoDto);
            return CreatedAtAction(nameof(GetById), new { id = procedimentoDto.Id }, procedimentoDto);
        }

        // PUT: api/Procedimento/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, [FromBody] ProcedimentoDto procedimentoDto)
        {
            if (procedimentoDto == null || id != procedimentoDto.Id)
                return BadRequest("Dados inválidos.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _procedimentoService.Update(procedimentoDto);
            return NoContent();
        }

        // DELETE: api/Procedimento/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var procedimentoDto = await _procedimentoService.GetProcedimentoById(id);

            if (procedimentoDto == null)
                return NotFound($"Procedimento não encontrado.");

            await _procedimentoService.Delete(id);
            return Ok($"Procedimento foi removido com sucesso.");
        }
    }
}
