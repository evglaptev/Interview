using MediatR;

namespace SberInterview.WebApi.Users
{
    public abstract class UserCommadBase<TRes> : IRequest<TRes>
    {
        public string Login { get; set; }
    }
}
