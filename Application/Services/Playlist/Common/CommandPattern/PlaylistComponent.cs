namespace Core.Services.Playlist.Common.CommandPattern;

public interface IPlaylistComponent
{
    string Name { get; set; }
    string Base64 { get; set; }
    public IEnumerable<string> GetName();
    public IEnumerable<string> GetBase64();
    public IPlaylistComponent GetChild(int i);
    public void Remove(IPlaylistComponent component);
    public void Add(IPlaylistComponent component);
}