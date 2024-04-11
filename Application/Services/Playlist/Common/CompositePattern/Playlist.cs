
namespace Core.Services.Playlist.Common.CompositePattern;

public class Playlist(string name) : IPlaylistComponent
{
    readonly ICollection<IPlaylistComponent> _playlistComponents = new List<IPlaylistComponent>();
    public string Name { get; set; } = name;
    public string Base64 { get; set; }

    public IEnumerable<string> GetName()
    {
        var listOfNames = new List<string>();
        using var iterator = _playlistComponents.GetEnumerator();
        while (iterator.MoveNext())
        {
            var playlistComponent = iterator.Current;
            var enumerable = listOfNames.Concat(playlistComponent.GetName()).ToList();
            listOfNames = enumerable;
        }
        
        return listOfNames;
    }

    public IEnumerable<string> GetBase64()
    {
        var listOfBase64 = new List<string>();
        using var iterator = _playlistComponents.GetEnumerator();
        while (iterator.MoveNext())
        {
            var playlistComponent = iterator.Current;
            var enumerable = listOfBase64.Concat(playlistComponent.GetBase64()).ToList();
            listOfBase64 = enumerable;
        }
        
        return listOfBase64;
    }

    public IPlaylistComponent GetChild(int i)
    {
        return _playlistComponents.ElementAt(i);
    }

    public void Remove(IPlaylistComponent component)
    {
        _playlistComponents.Remove(component);
    }

    public void Add(IPlaylistComponent component)
    {
        _playlistComponents.Add(component);
    }
}