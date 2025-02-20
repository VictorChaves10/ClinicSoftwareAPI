using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;

namespace ClinicSoftwareAPI.Filters;

public class ForeignKeyConstraintExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ForeignKeyConstraintExceptionFilter> _logger;

    public ForeignKeyConstraintExceptionFilter(ILogger<ForeignKeyConstraintExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (context.Exception is Microsoft.EntityFrameworkCore.DbUpdateException dbUpdateEx
            && dbUpdateEx.InnerException is SqlException sqlEx
            && sqlEx.Number == 547) // Código 547: Violação de FK
        {
            _logger.LogError(sqlEx, "Erro de integridade referencial.");

            context.Result = new ObjectResult(new
            {
                StatusCode = 400,
                Message = "Não é possível excluir o registro pois ele possui dependências em outras tabelas."
            })
            {
                StatusCode = 400
            };

            context.ExceptionHandled = true;
        }
    }
}
