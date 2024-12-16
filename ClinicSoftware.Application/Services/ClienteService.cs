using AutoMapper;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Domain.Entities.Cliente;
using ClinicSoftware.Domain.Interfaces;

namespace ClinicSoftware.Application.Services;

public class ClienteService(IUnitOfWork unitOfWork, IMapper mapper) : IClienteService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ClienteDto>> GetClientes()
    {
        var clientes = await _unitOfWork.ClienteRepository.GetAllAsync();

        ArgumentNullException.ThrowIfNull(clientes);

        var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

        return clientesDto;
    }

    public async Task<ClienteDto> GetClienteById(int id)
    {
        var cliente = await _unitOfWork.ClienteRepository.GetAsync(x => x.Id == id);

        ArgumentNullException.ThrowIfNull(cliente);

        var clienteDto = _mapper.Map<ClienteDto>(cliente);

        return clienteDto;
    }

    public async Task Add(ClienteDto clienteDto)
    {
        ArgumentNullException.ThrowIfNull(clienteDto);

        var cliente = _mapper.Map<Cliente>(clienteDto);

        _unitOfWork.ClienteRepository.Create(cliente);
        await _unitOfWork.CommitAsync();
    }

    public async Task Update(ClienteDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);

        _unitOfWork.ClienteRepository.Update(cliente);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(ClienteDto clienteDto)
    {
        var cliente = await _unitOfWork.ClienteRepository.GetAsync(x => x.Id == clienteDto.Id);

        ArgumentNullException.ThrowIfNull(cliente);

        _unitOfWork.ClienteRepository.Delete(cliente);
        await _unitOfWork.CommitAsync();
    }

}
