using System.ComponentModel.DataAnnotations;

namespace DrumBeatsAPI.Models;

public class Exercise
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
}