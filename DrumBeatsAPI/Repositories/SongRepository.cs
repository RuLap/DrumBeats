using DrumBeatsAPI.Models;
using DrumBeatsAPI.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DrumBeatsAPI.Repositories;

public class SongRepository : ISongRepository
{
    private readonly DrumBeatsContext _context;

    public SongRepository(DrumBeatsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Song>> Get()
    {
        return await _context.Songs
            .Include(s => s.Album)
            .Include(s => s.Artist)
            .ToListAsync();
    }

    public async Task<Song> Get(int id)
    {
        return await _context.Songs
            .Include(s => s.Album)
            .Include(s => s.Artist)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Song> Create(Song song)
    {
        _context.Songs.Add(song);
        await _context.SaveChangesAsync();

        return song;
    }

    public async Task Update(Song song)
    {
        _context.Entry(song).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deleteSong = await _context.Songs.FindAsync(id);
        _context.Songs.Remove(deleteSong);
        await _context.SaveChangesAsync();
    }
}