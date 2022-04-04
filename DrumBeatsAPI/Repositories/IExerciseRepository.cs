using DrumBeatsAPI.Models;

namespace DrumBeatsAPI.Repositories;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> Get();
    
    Task<Exercise> Get(int id);

    Task<Exercise> Create(Exercise exercise);

    Task Update(Exercise exercise);

    Task Delete(int id);
}