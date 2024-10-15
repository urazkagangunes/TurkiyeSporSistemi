using TurkiyeSporSisemi.ConsoleUI.Service;
using TurkiyeSporSistemi.Models;
using TurkiyeSporSistemi.Models.Enums;
using TurkiyeSporSistemi.Repository;
using TurkiyeSporSistemi.Service;
namespace TurkiyeSporSistemi;

public class Program
{
    static void Main(string[] args)
    {
        Player update = new Player
        {
            Id = 2,
            Name = "edin",
            Surname = "dzeko",
            Gender = Gender.Male,
            Branch = Branch.Futbol,
            MarketValue = 100000,
            ShirtNumber = "99",
            Position = "forvet",
            TeamId = new Guid("{d243a789-1884-4ab0-a4b0-e355575020ed}")
        };
        PlayerService playerservice = new PlayerService();
        Console.WriteLine(playerservice.Update(2, update));

        Team updateTeam = new Team
        {
            Id = new Guid("{4C7E274B-6A4F-4697-9761-E16E7D26EBF5}"),
            Name = "BUUUU",
            Description = "Trabzonspor Açıklaması",
            Since = new DateTime(1967, 1, 4)
        };

        TeamService teamService = new TeamService();
        Console.WriteLine(teamService.Update(new Guid("{4C7E274B-6A4F-4697-9761-E16E7D26EBF5}"), updateTeam));

    }
}
