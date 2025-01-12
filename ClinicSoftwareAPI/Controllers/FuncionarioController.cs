using ClinicSoftware.Application.Dtos;
using ClinicSoftware.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSoftwareAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController(IFuncionarioService funcionarioService) : ControllerBase
{
    private readonly IFuncionarioService _funcionarioService = funcionarioService;

    // GET: api/Funcionario
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var funcionarios = await _funcionarioService.GetFuncionarios();

        if (!funcionarios.Any())
            return NotFound("Nenhum funcionario encontrado.");

        return Ok(funcionarios);
    }

    // GET: api/Funcionario/{id}
    [HttpGet("{id:long}", Name = "ObterFuncionario")]
    public async Task<IActionResult> GetById(long id)
    {
        var funcionario = await _funcionarioService.GetFuncionarioById(id);

        return funcionario == null
            ? NotFound($"Funcionario não encontrado.")
            : Ok(funcionario);
    }

    // POST: api/Funcionario
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FuncionarioDto funcionarioDto)
    {
        if (funcionarioDto == null)
            return BadRequest("Dados do funcionario não são inválidos.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _funcionarioService.Add(funcionarioDto);
        return CreatedAtAction(nameof(GetById), new { id = funcionarioDto.Id }, funcionarioDto);
    }

    // PUT: api/Funcionario/{id}
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Put(long id, [FromBody] FuncionarioDto funcionarioDto)
    {
        if (funcionarioDto == null || id != funcionarioDto.Id)
            return BadRequest("Dados do funcionario não são inválidos.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _funcionarioService.Update(funcionarioDto);
        return NoContent();
    }

    // DELETE: api/Funcionario/{id}
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var funcionarioDto = await _funcionarioService.GetFuncionarioById(id);

        if (funcionarioDto == null)
            return NotFound($"Funcionario não encontrado.");

        await _funcionarioService.Delete(id);
        return Ok($"Funcionario foi removido com sucesso.");
    }
}
