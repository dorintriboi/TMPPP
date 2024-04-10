namespace Core.Services.Playlist.Common.CommandPattern;

public class Music(string name, string base64) : IPlaylistComponent
{
    public string Name { get; set; } = name;
    public string Base64 { get; set; } = base64;

    public IEnumerable<string> GetName()
    {
        return new List<string> { Name };
    }

    public IEnumerable<string> GetBase64()
    {
        return new List<string> { Base64 };
    }

    public IPlaylistComponent GetChild(int i)
    {
        throw new NotImplementedException();
    }

    public void Remove(IPlaylistComponent component)
    {
        throw new NotImplementedException();
    }

    public void Add(IPlaylistComponent component)
    {
        throw new NotImplementedException();
    }
}