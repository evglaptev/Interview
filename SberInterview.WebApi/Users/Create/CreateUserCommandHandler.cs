using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SberInterview.WebApi.Users.Create;

// ReSharper disable All

namespace SberInterview.WebApi.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly SberDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(SberDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            // Валидация нужна во всех Handle, но должна выглядеть иначе. Можно расширить интерфейс IRequest методом Validate
            if (command == null && command.Email == null && command.FirstName == null && command.LastName == null && command.Login == null && command.Password == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Add(_mapper.Map<User>(command));
            _context.SaveChanges();
            
            return Unit.Value;
        }
    }
}