using System.Threading;
using System.Threading.Tasks;

namespace SberInterview.WebApi.Data.Repository.User
{
    public interface IUserRepository
    {
        public Task<Users.User> GetUserByLoginAsync(string login, CancellationToken cancellationToken);
        public Task AddAccountToUserAsync(string login);
    }
}
