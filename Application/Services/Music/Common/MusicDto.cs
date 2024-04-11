using Domain.Entities.Music;

namespace Core.Services.Music.Common;

public class MusicDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Base64 { get; set; }

    public static MusicDto From(MusicEntity entity)
    {
        return new MusicDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Base64 = entity.Base64
        };
    }
}