using TurkiyeSporSistemi.Models.Enums;

namespace TurkiyeSporSistemi.Models;

public class Player : Entity<int>  
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Gender Gender { get; set; }
    public string ShirtNumber { get; set; }
    public string Position { get; set; }
    public Branch Branch { get; set; }
    public double MarketValue { get; set; }

    public Guid TeamId { get; set; }
    public override string ToString()
    {
        return $"{Name}, {Surname}, {Gender},{Branch}, {ShirtNumber}, {Position}, {MarketValue}, {TeamId}";
    }
}
