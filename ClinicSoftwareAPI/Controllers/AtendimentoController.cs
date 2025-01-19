using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
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

    [HttpPost]
    public async Task<IActionResult> CriarAtendimento([FromBody] AtendimentoDto atendimentoDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var atendimento = await _atendimentoService.AddAtendimentoAsync(atendimentoDto);
        return Ok(atendimento);
        
    }
}