using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SberInterview.WebApi.Accounts;
using SberInterview.WebApi.Data.Repository.User;
using SberInterview.WebApi.Users.Create;
using SberInterview.WebApi.Users.Get;

// ReSharper disable All

namespace SberInterview.WebApi.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        
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
            var accounts = _mediator.Send(new GetUserAccountsQuery
            {
                Login = login
            });

            // Я бы перенёс отсюда мапер на уровни ниже. И убрал бы маппер из зависимостей из данного контроллера
            return _mapper.Map<List<AccountVm>>(accounts);
        }

        [HttpPost("/createUser")]
        public async Task CreateUserAsync([FromQuery] CreateUserCommand command)
        {
            await _mediator.Send(command);
        }

        [Authorize]
        [HttpPost("/add")]
        public async Task AddAccountToUserAsync([FromQuery] AddUserAccountCommand command)
        {
            await _mediator.Send(command);
        }
    }
}