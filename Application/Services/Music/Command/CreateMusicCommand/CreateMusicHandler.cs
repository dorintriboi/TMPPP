using Core.Services.Music.Common;
using Domain.Entities.Music;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Music.Command.CreateMusicCommand;

public class CreateMusicHandler(IApplicationUnitOfWork repository) : IRequestHandler<DTOs.CreateMusicCommand, MusicDto>
{
    public async Task<MusicDto> Handle(DTOs.CreateMusicCommand request, CancellationToken cancellationToken)
    {
        var music = new MusicEntity();
        music.Name = request.Name;
        await using var memoryStream = new MemoryStream();

        await request.File.CopyToAsync(memoryStream, cancellationToken);

        byte[] b = memoryStream.ToArray();

        music.Base64 = Convert.ToBase64String(b);

        await repository.MusicRepository.InsertAsync(music);
        await repository.SaveAsync();
        
        return MusicDto.From(music);
    }
}