using Core.Services.Music.Common;
using Core.Validations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Services.Music.Command.CreateMusicCommand.DTOs;

public class CreateMusicCommand: BaseMediatorDtoValidation<CreateMusicCommand>, IRequest<MusicDto>
{
    public string Name { get; set; }
    public IFormFile File { get; set; }
    
    protected override void Validation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name most be not null");
        
        RuleFor(x => x.File)
            .NotEmpty()
            .WithMessage("File most be not null");
    }
}