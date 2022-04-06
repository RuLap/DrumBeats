using DrumBeatsUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DrumBeatsUI.Controllers;

public class SongController : Controller
{
    private readonly ISongService _songService;

    public SongController(ISongService songService)
    {
        _songService = songService;
    }

    public async Task<IActionResult> Songs()
    {
        var songs = await _songService.GetSongs();
        
        return View(songs);
    }
}