using TurkiyeSporSistemi.Models;

namespace TurkiyeSporSistemi.Repository.Abstracts;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
{
    TEntity Add(TEntity created);
    TEntity? GetById(TId id);
    TEntity? Delete(TId id);
    List<TEntity> GetAll();
    TEntity? Update(TId id, TEntity entity);
}