namespace DrumBeatsUI.Models;

public class Song
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public int Duration { get; set; }
    
    public Artist Artist { get; set; }
    
    public Album Album { get; set; }

    public string GetDuration()
    {
        return $"{Duration / 60:D2}:{Duration % 60:D2}";
    }
}