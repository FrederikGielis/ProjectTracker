namespace ProjectTracker.Models;

public class CreateProjectInputModel
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int OwnerUserId { get; set; }
    public decimal Budget { get; set; }
}
