using DrumBeatsAPI.Models;
using DrumBeatsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumBeatsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAlbumRepository _albumRepository;

    public AlbumController(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Album>> GetAlbums()
    {
        return await _albumRepository.Get();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Album>> GetAlbums(int id)
    {
        return await _albumRepository.Get(id);
    }

    [HttpPost]
    public async Task<ActionResult<Album>> PostAlbum([FromBody] Album album)
    {
        var newAlbum = await _albumRepository.Create(album);
        return CreatedAtAction(nameof(GetAlbums), new {id = newAlbum}, newAlbum);
    }

    [HttpPut]
    public async Task<ActionResult> PutAlbum(int id, [FromBody] Album album)
    {
        if (id != album.Id)
        {
            return BadRequest();
        }

        await _albumRepository.Update(album);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAlbum(int id)
    {
        var deleteAlbum = await _albumRepository.Get(id);
        if (deleteAlbum == null)
        {
            return NotFound();
        }

        await _albumRepository.Delete(deleteAlbum.Id);

        return NoContent();
    }
}