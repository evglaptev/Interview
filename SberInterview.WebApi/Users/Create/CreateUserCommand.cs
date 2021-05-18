using MediatR;

namespace SberInterview.WebApi.Users.Create
{
    public class CreateUserCommand : UserCommadBase<Unit>
    {
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        //  ак можно создать пользовател€ без парол€?
        public string Password { get; set; }
    }
}