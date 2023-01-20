using Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviour
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        //private readonly ICurrentUserService _currentUserService;
        //private readonly IIdentityService _identityService;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
            // _currentUserService = currentUserService;
            //_identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            //  var userId = _currentUserService.UserId ?? string.Empty;
            string userName = string.Empty;

            if (!string.IsNullOrEmpty(""))
            {
                //   userName = await _identityService.GetUserNameAsync(userId);
                await Task.FromResult("");
            }

            _logger.LogInformation("test Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, "", userName, request);
        }
    }
}
