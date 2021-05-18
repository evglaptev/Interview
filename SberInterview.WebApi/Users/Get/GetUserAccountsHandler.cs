using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SberInterview.WebApi.Accounts;

namespace SberInterview.WebApi.Users.Get
{
    public class GetUserAccountsHandler : IRequestHandler<GetUserAccountsQuery, ICollection<Account>>
    {
        private readonly UsersRepository _usersRepository;
        private readonly ILogger<GetUserByLoginQueryHandler> _logger;

        public GetUserAccountsHandler(UsersRepository usersRepository, ILoggerFactory loggerFactory)
        {
            _usersRepository = usersRepository;
            _logger = loggerFactory.CreateLogger<GetUserByLoginQueryHandler>();
        }

        public async Task<ICollection<Account>> Handle(GetUserAccountsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            try
            {
                var user = await _usersRepository.GetUserByLoginAsync(request.Login, cancellationToken);
                return user.Accounts;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
