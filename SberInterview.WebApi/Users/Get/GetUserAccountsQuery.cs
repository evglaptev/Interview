using MediatR;
using SberInterview.WebApi.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberInterview.WebApi.Users.Get
{
    public class GetUserAccountsQuery : UserCommadBase<ICollection<Account>>
    {
    }
}
