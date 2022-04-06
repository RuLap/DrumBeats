using AutoMapper;
using DrumBeatsUI.Models;
using DrumBeatsUI.Models.Respones;
using Newtonsoft.Json;

namespace DrumBeatsUI.Services;

public class SongService : ISongService
{
    private readonly HttpClient _client;

    private readonly IMapper _mapper;

    public SongService(
        HttpClient client,
        IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Song>> GetSongs()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/Song");

        var response = await _client.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<IEnumerable<Song>>(json);

        return responseObject;
    }

    public async Task<Song> GetSong(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/Song/{id}");

        var response = await _client.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<Song>(json);

        return responseObject;
    }
}