using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClinicSoftwareAPI.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Um erro ocorreu durante a solicitação: Status Code 500.");

            context.Result = new ObjectResult(new
            {
                StatusCode = 500,
                Message = "Ocorreu um erro interno no servidor. Por favor, tente novamente mais tarde."
            })
            {
                StatusCode = 500
            };
        }
    }
}
