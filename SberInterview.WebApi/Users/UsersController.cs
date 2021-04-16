using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SberInterview.WebApi.Accounts;
using SberInterview.WebApi.Users.Create;
using SberInterview.WebApi.Users.Get;

// ReSharper disable All

namespace SberInterview.WebApi.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController
    {
        private readonly IMediator _mediator;
        private readonly SberDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, SberDbContext context, IMapper mapper)
        {
            _mediator = mediator;
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("{login}")]
        public async Task<User> GetUserByLoginAsync([FromBody] string login)
        {
            return await _mediator.Send(new GetUserByLoginQuery
            {
                Login = login
            });
        }

        [Authorize]
        [HttpGet("{login}/accounts")]
        public async Task<List<AccountVm>> GetUserAccountsAsync([FromBody] string login)
        {
            var accounts = _context.Users
                .ToList()
                .Where(u => u.Login == login)
                .Select(u => u.Accounts);

            return _mapper.Map<List<AccountVm>>(accounts);
        }

        [HttpPost("/createUser")]
        public async Task CreateUserAsync([FromQuery] CreateUserCommand command)
        {
            await _mediator.Send(command);
        }

        [HttpGet("add")]
        public async Task AddAccountToUserAsync(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            user.Accounts = new List<Account>
            {
                new Account
                {
                    UserLogin = user.Login
                }
            };

            _context.SaveChangesAsync().Wait();
        }
    }
}