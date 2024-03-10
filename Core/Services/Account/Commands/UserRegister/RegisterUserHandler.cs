using Core.Services.Account.Commands.UserRegister.DTOs;
using Domain.Entities.User;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.Services.Account.Commands.UserRegister;

public class RegisterUserHandler(
    IApplicationUnitOfWork applicationUnitOfWork,
    UserManager<UserEntity> userManager) : IRequestHandler<RegisterUserCommand>
{
    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = UserEntity.Create(request.FirstName, request.LastName, request.Password, request.Email,
            request.PhoneNumber);
        
        IdentityResult result = new IdentityResult();
        await applicationUnitOfWork.StartTransactionAsync();
        try
        {
            var result1 = await userManager.CreateAsync(user, request.Password);
            result = result1;
        }
        catch (DbUpdateException)
        {
            throw new Exception("The phone number most be unique");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
        if (!result.Succeeded)
        {
            var errorMessage = string.Join('\n', result.Errors.Select(x => x.Description).ToArray());
            throw new Exception(errorMessage);
        }

        var addToRole = await userManager.AddToRoleAsync(user, "User");

        if (!addToRole.Succeeded)
        {
            var errorMessage = string.Join('\n', result.Errors.Select(x => x.Description).ToArray());
            throw new Exception(errorMessage);
        }

        await applicationUnitOfWork.CommitAsync();
    }
}