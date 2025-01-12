using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSoftwareAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController(IClienteService clienteService) : ControllerBase
{
    private readonly IClienteService _clienteService = clienteService;

    // GET: api/Cliente
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clientes = await _clienteService.GetClientes();

        if (!clientes.Any())
            return NotFound("Nenhum cliente encontrado.");

        return Ok(clientes);
    }

    // GET: api/Cliente/{id}
    [HttpGet("{id:long}", Name = "ObterCliente")]
    public async Task<IActionResult> GetById(long id)
    {
        var cliente = await _clienteService.GetClienteById(id);

        return cliente == null
            ? NotFound($"Cliente não encontrado.")
            : Ok(cliente);
    }

    // POST: api/Cliente
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClienteDto clienteDto)
    {
        if (clienteDto == null)
            return BadRequest("Dados do cliente são inválidos.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _clienteService.Add(clienteDto);
        return CreatedAtAction(nameof(GetById), new { id = clienteDto.Id }, clienteDto);
    }

    // PUT: api/Cliente/{id}
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Put(long id, [FromBody] ClienteDto clienteDto)
    {
        if (clienteDto == null || id != clienteDto.Id)
            return BadRequest("Dados do cliente são inválidos.");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _clienteService.Update(clienteDto);
        return NoContent();
    }

    // DELETE: api/Cliente/{id}
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var clienteDto = await _clienteService.GetClienteById(id);

        if (clienteDto == null)
            return NotFound($"Cliente não encontrado.");

        await _clienteService.Delete(id);
        return Ok($"Cliente foi removido com sucesso.");
    }
}
