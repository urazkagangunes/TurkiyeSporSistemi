using TurkiyeSporSistemi.Exceptions;
using TurkiyeSporSistemi.Models.ReturnModels;
using TurkiyeSporSistemi.Models;
using System.Net;
using ValidationException = TurkiyeSporSistemi.Exceptions.ValidationException;
using TurkiyeSporSisemi.ConsoleUI.Repository.Concrete;

namespace TurkiyeSporSisemi.ConsoleUI.Service;

public class PlayerService : IPlayerService
{

    PlayerRepository playerRepository  = new PlayerRepository();
    public ReturnModel<Player> GetById(int id)
    {
        try
        {
            Player player = playerRepository.GetById(id);
            return new ReturnModel<Player>
            {
                Data = player,
                Message = "Aradığınız Id ye göre Oyuncu bulundu",
                Success = true,
            };
        }
        catch (NotFoundException ex)
        {
            return ReturnModelOfException(ex);
        }

    }

    public ReturnModel<Player> Update(int id, Player updated)
    {

        try
        {
            CheckPlayerName(updated.Name);

            Player player = playerRepository.Update(id, updated);

            return new ReturnModel<Player>
            {
                Data = player,
                Message = "Oyuncu güncellendi",
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

    private void CheckPlayerName(string name)
    {
        if (name.Length < 1)
        {
            throw new ValidationException("Oyuncu ismi minimum 1 karakterli olmalıdır.");
        }
    }

    private ReturnModel<Player> ReturnModelOfException(Exception ex)
    {
        if(ex.GetType() == typeof(NotFoundException))
        {
            return new ReturnModel<Player>
            {
                Data = null,
                Message = ex.Message,
                Success = false,
                StatusCode = HttpStatusCode.NotFound
            };
        }

        if(ex.GetType() == typeof(ValidationException))
        {
            return new ReturnModel<Player>
            {
                Data = null,
                Message = ex.Message,
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        return new ReturnModel<Player>
        {
            Data = null,
            Message = ex.Message,
            Success = false,
            StatusCode = HttpStatusCode.InternalServerError
        };
        
    }
}