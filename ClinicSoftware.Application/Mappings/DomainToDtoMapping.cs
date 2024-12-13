using AutoMapper;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Domain.Entities.Cliente;

namespace ClinicSoftware.Application.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Cliente, ClienteDto>().ReverseMap();
    }
}
