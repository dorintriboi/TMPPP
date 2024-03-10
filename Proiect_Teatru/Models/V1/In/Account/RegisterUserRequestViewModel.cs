using Core.Interfaces.In;
using Core.Services.Account.Commands.UserRegister.DTOs;

namespace Proiect_Teatru.Models.V1.In.Account;

public class RegisterUserRequestViewModel : IRequest<RegisterUserCommand>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    
    public RegisterUserCommand Convert()
    {
        return new RegisterUserCommand()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber,
            Password = Password
        };
    }
}