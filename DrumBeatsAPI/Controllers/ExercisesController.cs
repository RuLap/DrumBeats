using DrumBeatsAPI.Models;
using DrumBeatsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrumBeatsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController : ControllerBase
{
    private readonly IExerciseRepository _exerciseRepository;
    
    public ExercisesController(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Exercise>> GetExercises()
    {
        return await _exerciseRepository.Get();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExercises(int id)
    {
        return await _exerciseRepository.Get(id);
    }

    [HttpPost]
    public async Task<ActionResult<Exercise>> PostExercise([FromBody] Exercise exercise)
    {
        var newExercise = await _exerciseRepository.Create(exercise);
        return CreatedAtAction(nameof(GetExercises), new {id = newExercise}, newExercise);
    }

    [HttpPut]
    public async Task<ActionResult> PutExercise(int id, [FromBody] Exercise exercise)
    {
        if (id != exercise.Id)
        {
            return BadRequest();
        }

        await _exerciseRepository.Update(exercise);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExercise(int id)
    {
        var deleteExercise = await _exerciseRepository.Get(id);
        if (deleteExercise == null)
        {
            return NotFound();
        }

        await _exerciseRepository.Delete(deleteExercise.Id);

        return NoContent();
    }
}