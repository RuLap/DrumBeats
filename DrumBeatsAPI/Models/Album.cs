using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrumBeatsAPI.Models;

public class Album
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
    
    public string Image { get; set; }

    [ForeignKey(nameof(Artist))]
    public int? ArtistId { get; set; }
    public Artist? Artist { get; set; }

    public ICollection<Song>? Songs { get; set; }
}