using DrumBeatsAPI.Models;
using DrumBeatsAPI.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DrumBeatsAPI.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly DrumBeatsContext _context;

    public AlbumRepository(DrumBeatsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Album>> Get()
    {
        return await _context.Albums
            .Include(a => a.Artist)
            .Include(a => a.Songs)
            .ToListAsync();
    }

    public async Task<Album> Get(int id)
    {
        return await _context.Albums
            .Include(a => a.Artist)
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Album> Create(Album album)
    {
        _context.Albums.Add(album);
        await _context.SaveChangesAsync();

        return album;
    }

    public async Task Update(Album album)
    {
        _context.Entry(album).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deleteAlbum = await _context.Albums.FindAsync(id);
        _context.Albums.Remove(deleteAlbum);
        await _context.SaveChangesAsync();
    }
}