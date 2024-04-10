namespace Core.Services.Playlist.Common;

public class PlaylistDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<string> Music { get; set; }
}