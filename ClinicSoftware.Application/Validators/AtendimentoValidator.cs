using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Domain.Interfaces;
using FluentValidation;

namespace ClinicSoftware.Application.Validators;

public class AtendimentoValidator : AbstractValidator<AtendimentoDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public AtendimentoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(a => a.IdCliente)
            .NotEmpty()
            .WithMessage("Informar o Cliente é obrigatório.")
            .MustAsync(async (id, cancellation) => await ClienteInexistenteAsync(id))
            .WithMessage("Não foi encontrado o cliente informado.");

        RuleFor(a => a.Procedimentos)
            .NotEmpty()
            .WithMessage("É necessário informar ao menos um procedimento.");
    }

    private async Task<bool> ClienteInexistenteAsync(long id)
    {
        var cliente = await _unitOfWork.ClienteRepository.GetAsync(x => x.Id == id);
        return cliente != null;
    }
}