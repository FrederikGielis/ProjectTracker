namespace ProjectTracker.Domain.Entities;

public class ProjectItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OwnerUserId { get; set; }
    public decimal Budget { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsArchived { get; set; }
}
