using AutoMapper;
using ClinicSoftware.Application.Dtos;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Domain.Entities.Atendimentos;
using ClinicSoftware.Domain.Entities.Clientes;
using ClinicSoftware.Domain.Entities.Financeiro;
using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Entities.Procedimentos;

namespace ClinicSoftware.Application.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        
        CreateMap<Funcionario, FuncionarioDto>().ReverseMap();

        CreateMap<Procedimento, ProcedimentoDto>().ReverseMap();

        CreateMap<Pagamento, PagamentoDto>().ReverseMap();

        CreateMap<AtendimentoProcedimento, AtendimentoProcedimentoDto>().ReverseMap();

    }

}
