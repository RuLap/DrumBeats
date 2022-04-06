namespace DrumBeatsUI.Models;

public class Album
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Image { get; set; }
    
    public Artist Artist { get; set; }

    public ICollection<Song> Songs { get; set; }
}