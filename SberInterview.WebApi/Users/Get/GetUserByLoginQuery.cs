using MediatR;

namespace SberInterview.WebApi.Users.Get
{
    public class GetUserByLoginQuery : IRequest<User>
    {
        public string Login { get; set; }
    }
}