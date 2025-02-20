using AutoMapper;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Domain.Entities.Clientes;
using ClinicSoftware.Domain.Interfaces;

namespace ClinicSoftware.Application.Services;

public class ClienteService(IUnitOfWork unitOfWork, IMapper mapper) : IClienteService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ClienteDto>> GetClientes()
    {
        var clientes = await _unitOfWork.ClienteRepository.GetAllAsync();
        var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

        return clientesDto;
    }

    public async Task<ClienteDto> GetClienteById(long id)
    {
        var cliente = await _unitOfWork.ClienteRepository.GetAsync(x => x.Id == id);
        return _mapper.Map<ClienteDto>(cliente);
    }

    public async Task Add(ClienteDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);
        cliente.Validar();

        _unitOfWork.ClienteRepository.Create(cliente);
        await _unitOfWork.CommitAsync();

        clienteDto.Id = cliente.Id;
    }

    public async Task Update(ClienteDto clienteDto)
    {
        var cliente = await _unitOfWork.ClienteRepository.GetAsync(x => x.Id == clienteDto.Id);

        if (cliente == null)
            throw new ArgumentException("Cliente não encontrado.");

        cliente.Atualizar(nome: clienteDto.Nome,
                          email: clienteDto.Email,
                          telefone: clienteDto.Telefone,
                          endereco: clienteDto.Endereco,
                          cpf: clienteDto.CPF,
                          datanascimento: clienteDto.DataNascimento ?? cliente.DataNascimento
         );

        cliente.Validar();

        _unitOfWork.ClienteRepository.Update(cliente);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(long id)
    {
        var cliente = await _unitOfWork.ClienteRepository.GetAsync(x => x.Id == id);

        if (cliente == null)
            throw new KeyNotFoundException("Cliente não encontrado.");

        _unitOfWork.ClienteRepository.Delete(cliente);
        await _unitOfWork.CommitAsync();
    }

}
