using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSoftwareAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoService _atendimentoService;

    public AtendimentoController(IAtendimentoService atendimentoService)
    {
        _atendimentoService = atendimentoService;
    }

    // GET: api/Atendimento/{id}
    [HttpGet("{id:long}", Name = "ObterAtendimento")]
    public async Task<IActionResult> GetById(long id)
    {
        var atendimentoDto = await _atendimentoService.GetAtendimentoByIdAsync(id);
        return atendimentoDto == null 
            ? NotFound($"Cliente não encontrado.")
            : Ok(atendimentoDto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AtendimentoDto atendimentoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _atendimentoService.AddAtendimentoAsync(atendimentoDto);
        return CreatedAtAction(nameof(GetById), new { id = atendimentoDto.Id }, atendimentoDto);

    }
}