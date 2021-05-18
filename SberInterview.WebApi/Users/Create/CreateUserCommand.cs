using MediatR;

namespace SberInterview.WebApi.Users.Create
{
    public class CreateUserCommand : UserCommadBase<Unit>
    {
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        // ��� ����� ������� ������������ ��� ������?
        public string Password { get; set; }
    }
}