using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Configuration;
using Core.Services.Account.Queries.Login.DTOs;
using Domain.Entities.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services.Account.Queries.Login;

public class LoginHandler(
    UserManager<UserEntity> userManager,
    AuthOptions authOptions) : IRequestHandler<LoginQuery, string>
{
    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Username);
        if (user == null)
        {
            var errorMessage = "Login failed - Nu such username in database";
            throw new Exception(errorMessage);
        }

        var validPassword = await userManager.CheckPasswordAsync(user, request.Password);
        if (!validPassword)
        {
            const string errorMessage = "Login failed - Password not valid";
            throw new Exception(errorMessage);
        }

        var role = await userManager.GetRolesAsync(user);
        var claims = new List<Claim>()
        {
            new(nameof(UserEntity.Id), user.Id),
            new(nameof(UserEntity.UserName), user.UserName ?? string.Empty),
            new(nameof(UserEntity.Email), user.Email ?? string.Empty),
            new(ClaimTypes.Role, role.First())
        };

        var signinCredentials = new SigningCredentials(authOptions.GetSymmetricSecurityKey(),
            SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: authOptions.Issuer,
            audience: authOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: signinCredentials
        );
        var tokenHandler = new JwtSecurityTokenHandler();

        var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

        return encodedToken;
    }
}