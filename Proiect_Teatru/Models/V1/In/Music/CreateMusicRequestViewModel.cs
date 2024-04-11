using Core.Services.Music.Command.CreateMusicCommand.DTOs;
using MediatR;

namespace Proiect_Teatru.Models.V1.In.Music;

public class CreateMusicRequestViewModel: IRequest<CreateMusicCommand>
{
    public string Name { get; set; }
    public IFormFile File { get; set; }

    public CreateMusicCommand Convert()
    {
        return new CreateMusicCommand()
        {
            Name = Name,
            File = File
        };
    }
}