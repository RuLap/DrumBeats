using DrumBeatsAPI.Models;
using DrumBeatsAPI.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DrumBeatsAPI.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly DrumBeatsContext _context;

    public ArtistRepository(DrumBeatsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Artist>> Get()
    {
        return await _context.Artists
            .Include(a => a.Albums)
            .Include(a => a.Songs)
            .ToListAsync();
    }

    public async Task<Artist> Get(int id)
    {
        return await _context.Artists
            .Include(a => a.Albums)
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Artist> Create(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();

        return artist;
    }

    public async Task Update(Artist artist)
    {
        _context.Entry(artist).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deleteArtist = await _context.Artists.FindAsync(id);
        _context.Artists.Remove(deleteArtist);
        await _context.SaveChangesAsync();
    }
}