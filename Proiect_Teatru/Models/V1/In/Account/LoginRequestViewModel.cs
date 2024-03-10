using Core.Services.Account.Queries.Login.DTOs;

namespace Proiect_Teatru.Models.V1.In.Account;

public class LoginRequestViewModel : Core.Interfaces.In.IRequest<LoginQuery>
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginQuery Convert()
    {
        return new LoginQuery()
        {
            Username = Username,
            Password = Password
        };
    }
}