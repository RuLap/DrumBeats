using AutoMapper;
using DrumBeatsUI.Models;
using DrumBeatsUI.Models.Respones;
using Newtonsoft.Json;

namespace DrumBeatsUI.Services;

public class ExerciseService : IExerciseService
{
    private readonly HttpClient _client;

    private readonly IMapper _mapper;

    public ExerciseService(
        HttpClient client,
        IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Exercise>> GetExercises()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/Exercises");

        var response = await _client.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<IEnumerable<ExerciseResponse>>(json);

        return responseObject?.Select(i => _mapper.Map<Exercise>(i));
    }

    public async Task<Exercise> GetExercise(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"api/Exercises/{id}");

        var response = await _client.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<ExerciseResponse>(json);

        return _mapper.Map<Exercise>(responseObject);
    }
}