namespace PeopleRegistration.Shared.Domain.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    Task<List<T>> GetAll();
    Task<T?> Get(Guid id);
    Task Update(T entity);
    Task Insert(T entity);
    Task<int> Delete(Guid id);
}