using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSoftwareAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var clientes = await _clienteService.GetClientes();

        if (!clientes.Any())
            return NotFound();

        return Ok(clientes);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDto>> Post(ClienteDto clienteDto)
    {
        if (clienteDto is null)
            return BadRequest();

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        await _clienteService.Add(clienteDto);
        return Ok();
    }
}
