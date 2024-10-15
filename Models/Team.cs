namespace TurkiyeSporSistemi.Models;

public class Team : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Since { get; set; }
}
