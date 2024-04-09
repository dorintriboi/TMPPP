using Core.Services.Account.Queries.Login.DTOs;
using Proiect_Teatru.Models.Interfaces.In;

namespace Proiect_Teatru.Models.V1.In.Account;

public class LoginRequestViewModel : IRequest<LoginQuery>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginQuery Convert()
    {
        return new LoginQuery()
        {
            Email = Email,
            Password = Password
        };
    }
}