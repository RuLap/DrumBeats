using DrumBeatsUI.Models;
using DrumBeatsUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DrumBeatsUI.Controllers;

public class ExerciseController : Controller
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    public async Task<IActionResult> Exercises()
    {
        var exercises = await _exerciseService.GetExercises();
        
        return View(exercises);
    }
}