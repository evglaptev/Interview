using Microsoft.EntityFrameworkCore;
using SberInterview.WebApi.Accounts;
using SberInterview.WebApi.Data.Repository.User;
using System.Threading;
using System.Threading.Tasks;

namespace SberInterview.WebApi.Users
{
    public class UsersRepository : IUserRepository
    {
        private readonly SberDbContext _context;

        public UsersRepository(SberDbContext context)
        {
            _context = context;
        }
        
        public async Task<User> GetUserByLoginAsync(string login, CancellationToken cancellationToken) 
        {
            // Есть ли метод, который не будет проверять всю бд, а вернёт первое вхождение? 
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login, cancellationToken);
        }
        public async Task AddAccountToUserAsync(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            
            if (user == null)
            {
                //throw new NotFoundException($"user {login}");
            }

            user.Accounts.Add(new Account
            {
                UserLogin = user.Login
            });
            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }
    }
}