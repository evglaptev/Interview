using SberInterview.WebApi.Users;

namespace SberInterview.WebApi.Accounts
{
    public class Account
    {
        public int Id { get; set; }
        
        public double Balance { get; set; }
        
        public User User { get; set; }
        
        // UserLogin �� �����, ������ ��� ���� ������ �� �����
        public string UserLogin { get; set; }
    }
}