using TurkiyeSporSistemi.Models.ReturnModels;
using TurkiyeSporSistemi.Models;

namespace TurkiyeSporSistemi.Service;

public interface ITeamService
{
    ReturnModel<Team> GetById(Guid id);
    ReturnModel<Team> Update(Guid id, Team updated);

}
