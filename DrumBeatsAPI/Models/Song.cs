using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrumBeatsAPI.Models;

public class Song
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public int Duration { get; set; }

    [ForeignKey(nameof(Artist))]
    public int? ArtistId { get; set; }
    public virtual Artist? Artist { get; set; }

    [ForeignKey(nameof(Album))] 
    public int? AlbumId { get; set; }
    public virtual Album? Album { get; set; }
}