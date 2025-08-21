using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
namespace Application.Common.Behaviours;
public class LoggingBehaviour<TRequest>(ILogger<LoggingBehaviour<TRequest>> _logger) : IRequestPreProcessor<TRequest>
{
    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogInformation("Applicants Request: {@Name} {@Request}",
            requestName, request);
    }
}
