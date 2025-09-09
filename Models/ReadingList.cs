namespace WebSiteFanfic.Models;

public class ReadingList
{
    public Guid Id { get; set; }
    public string ListName { get; set; }
    public DateTime LastAlteration { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Fanfic> Fanfics { get; set; } = [];
}
