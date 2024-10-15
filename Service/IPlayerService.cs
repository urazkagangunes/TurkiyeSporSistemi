
using TurkiyeSporSistemi.Models;
using TurkiyeSporSistemi.Models.ReturnModels;

namespace TurkiyeSporSisemi.ConsoleUI.Service;

public interface IPlayerService
{
    ReturnModel<Player> GetById(int id);

    ReturnModel<Player> Update(int id, Player updated);
}