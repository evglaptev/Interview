using MediatR;
using SberInterview.WebApi.Data.Repository.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SberInterview.WebApi.Users.Create
{
    public class AddUserAccountHandler : IRequestHandler<AddUserAccountCommand>
    {
        private readonly IUserRepository _usersRepository;
        public AddUserAccountHandler(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Unit> Handle(AddUserAccountCommand command, CancellationToken cancellationToken)
        {
            if (command == null && command.Login == null)
                throw new ArgumentNullException(command.Login);

            await _usersRepository.AddAccountToUserAsync(command.Login);
            return Unit.Value;
        }
    }
}
