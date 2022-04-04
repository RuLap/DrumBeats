using DrumBeatsUI.Models;

namespace DrumBeatsUI.Services;

public interface IExerciseService
{
    Task<IEnumerable<Exercise>> GetExercises();

    Task<Exercise> GetExercise(int id);
}