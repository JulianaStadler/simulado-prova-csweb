namespace WebSiteFanfic.Models;


public class Fanfic
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public ICollection<ReadingList> ReadingLists { get; set; } = [];
}