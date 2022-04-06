using System.ComponentModel.DataAnnotations;

namespace DrumBeatsAPI.Models;

public class Artist
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    public string Image { get; set; }
    
    public virtual ICollection<Album>? Albums { get; set; }

    public virtual ICollection<Song>? Songs { get; set; }
}