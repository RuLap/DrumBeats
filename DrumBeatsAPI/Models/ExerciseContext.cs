using Microsoft.EntityFrameworkCore;

namespace DrumBeatsAPI.Models;

public class ExerciseContext : DbContext
{
    public ExerciseContext(DbContextOptions<ExerciseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Exercise> Exercises { get; set; }
}