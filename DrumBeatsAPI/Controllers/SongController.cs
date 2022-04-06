using DrumBeatsAPI.Models;
using DrumBeatsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumBeatsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SongController : ControllerBase
{
    private readonly ISongRepository _songRepository;

    public SongController(ISongRepository songRepository)
    {
        _songRepository = songRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Song>> GetSongs()
    {
        return await _songRepository.Get();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Song>> GetSongs(int id)
    {
        return await _songRepository.Get(id);
    }

    [HttpPost]
    public async Task<ActionResult<Song>> PostSong([FromBody] Song song)
    {
        var newSong = await _songRepository.Create(song);
        return CreatedAtAction(nameof(GetSongs), new {id = newSong}, newSong);
    }

    [HttpPut]
    public async Task<ActionResult> PutSong(int id, [FromBody] Song song)
    {
        if (id != song.Id)
        {
            return BadRequest();
        }

        await _songRepository.Update(song);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSong(int id)
    {
        var deleteSong = await _songRepository.Get(id);
        if (deleteSong == null)
        {
            return NotFound();
        }

        await _songRepository.Delete(deleteSong.Id);

        return NoContent();
    }
}