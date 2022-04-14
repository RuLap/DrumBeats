using DrumBeatsUI.Models;
using DrumBeatsUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DrumBeatsUI.Pages;

public class SongsModel : PageModel
{
    private readonly ISongService _songService;

    public IEnumerable<Song> Songs { get; set; }

    public SongsModel(ISongService songService)
    {
        _songService = songService;
    }
    
    public async Task OnGet()
    {
        Songs = await _songService.GetSongs();
    }

    public PartialViewResult OnGetAddSongPartial()
    {
        return new PartialViewResult
        {
            ViewName = "_AddSongPartial",
            ViewData = new ViewDataDictionary<Song>(ViewData, new Song { })
        };
    }
}