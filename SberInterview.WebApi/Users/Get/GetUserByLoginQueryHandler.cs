using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SberInterview.WebApi.Users.Get
{
    public class GetUserByLoginQueryHandler : IRequestHandler<GetUserByLoginQuery, User>
    {
        private readonly UsersRepository _usersRepository;
        private readonly ILogger<GetUserByLoginQueryHandler> _logger;

        public GetUserByLoginQueryHandler(UsersRepository usersRepository, ILoggerFactory loggerFactory)
        {
            _usersRepository = usersRepository;
            _logger = loggerFactory.CreateLogger<GetUserByLoginQueryHandler>();
        }

        public async Task<User> Handle(GetUserByLoginQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _usersRepository.GetUserByLoginAsync(request.Login).Result;
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return null;
        }
    }
}