using DrumBeatsAPI.Models;
using DrumBeatsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumBeatsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArtistController : ControllerBase
{
    private readonly IArtistRepository _artistRepository;

    public ArtistController(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Artist>> GetArtist()
    {
        return await _artistRepository.Get();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Artist>> GetArtists(int id)
    {
        return await _artistRepository.Get(id);
    }

    [HttpPost]
    public async Task<ActionResult<Song>> PostArtist([FromBody] Artist artist)
    {
        var newArtist = await _artistRepository.Create(artist);
        return CreatedAtAction(nameof(GetArtists), new {id = newArtist}, newArtist);
    }

    [HttpPut]
    public async Task<ActionResult> PutSong(int id, [FromBody] Artist artist)
    {
        if (id != artist.Id)
        {
            return BadRequest();
        }

        await _artistRepository.Update(artist);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteArtist(int id)
    {
        var deleteArtist = await _artistRepository.Get(id);
        if (deleteArtist == null)
        {
            return NotFound();
        }

        await _artistRepository.Delete(deleteArtist.Id);

        return NoContent();
    }
}