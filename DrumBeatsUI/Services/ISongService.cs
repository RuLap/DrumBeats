using DrumBeatsUI.Models;

namespace DrumBeatsUI.Services;

public interface ISongService
{
    Task<IEnumerable<Song>> GetSongs();

    Task<Song> GetSong(int id);
}