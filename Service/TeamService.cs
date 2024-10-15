using TurkiyeSporSistemi.Exceptions;
using TurkiyeSporSistemi.Models.ReturnModels;
using TurkiyeSporSistemi.Models;
using TurkiyeSporSistemi.Repository.Concrete;
using System.Net;

namespace TurkiyeSporSistemi.Service;

public class TeamService : ITeamService
{
    TeamRepository teamRepository = new TeamRepository();
    public ReturnModel<Team> GetById(Guid id)
    {
        try
        {
            Team team = teamRepository.GetById(id);
            return new ReturnModel<Team>
            {
                Data = team,
                Message = "Aradığınız id ye göre takım bulunamadı",
                Success = true,
            };
        }
        catch (NotFoundException ex) 
        {
            return ReturnModelOfException(ex);
        }
    }

    public ReturnModel<Team> Update(Guid id, Team updated)
    {
        try
        {
            CheckTeamName(updated.Name);

            Team team = teamRepository.Update(id, updated);

            return new ReturnModel<Team>
            {
                Data = team,
                Message = "Takım güncellendi",
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }


        catch (NotFoundException ex)
        {
            return ReturnModelOfException(ex);

        }
        catch (ValidationException ex)
        {
            return ReturnModelOfException(ex);
        }
    }

    private void CheckTeamName(string name)
    {
        if (name.Length < 1)
        {
            throw new ValidationException("Takım ismi minimum 1 karakterli olmalıdır.");
        }
    }
    private ReturnModel<Team> ReturnModelOfException(Exception ex)
    {
        if (ex.GetType() == typeof(NotFoundException))
        {
            return new ReturnModel<Team>
            {
                Data = null,
                Message = ex.Message,
                Success = false,
                StatusCode = HttpStatusCode.NotFound
            };
        }

        if (ex.GetType() == typeof(ValidationException))
        {
            return new ReturnModel<Team>
            {
                Data = null,
                Message = ex.Message,
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        return new ReturnModel<Team>
        {
            Data = null,
            Message = ex.Message,
            Success = false,
            StatusCode = HttpStatusCode.InternalServerError
        };

    }
}
