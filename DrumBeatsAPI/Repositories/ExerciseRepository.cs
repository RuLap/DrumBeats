using DrumBeatsAPI.Models;
using DrumBeatsAPI.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DrumBeatsAPI.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly DrumBeatsContext _context;

    public ExerciseRepository(DrumBeatsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Exercise>> Get()
    {
        return await _context.Exercises.ToListAsync();
    }

    public async Task<Exercise> Get(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }

    public async Task<Exercise> Create(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();

        return exercise;
    }

    public async Task Update(Exercise exercise)
    {
        _context.Entry(exercise).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deleteExercise = await _context.Exercises.FindAsync(id);
        _context.Exercises.Remove(deleteExercise);
        await _context.SaveChangesAsync();
    }
}