using System.Linq.Expressions;
namespace PeopleRegistration.Shared.Domain.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
    Task<T?> Get(Guid id);
    Task Update(T entity);
    Task Insert(T entity);
    Task<int> Delete(Guid id);
}