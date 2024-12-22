using Microsoft.EntityFrameworkCore;
using PeopleRegistration.Shared.Domain;
using PeopleRegistration.Shared.Domain.Interfaces;

namespace PeopleRegistration.Shared.Infrastructure;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{

    private readonly IPeopleRegistrationDb _peopleRegistrationDB;

    public Repository(IPeopleRegistrationDb peopleRegistrationDB)
    {
        _peopleRegistrationDB = peopleRegistrationDB;
    }

    public virtual async Task<List<TEntity>> GetAll() => await _peopleRegistrationDB.DbContext.Set<TEntity>().ToListAsync();

    public async Task<TEntity> Get(Guid id)
    {
        var result = await _peopleRegistrationDB.DbContext.Set<TEntity>().FirstOrDefaultAsync(f => f.Id == id);

        return result ?? Activator.CreateInstance<TEntity>();
    }

    public async Task Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.Now;

        _peopleRegistrationDB.DbContext.Set<TEntity>().Update(entity);
        await _peopleRegistrationDB.DbContext.SaveChangesAsync();
    }

    public async Task Insert(TEntity entity)
    {
        await _peopleRegistrationDB.DbContext.Set<TEntity>().AddAsync(entity);
        await _peopleRegistrationDB.DbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Guid id)
    {
        var entity = await _peopleRegistrationDB.DbContext.Set<TEntity>().FirstOrDefaultAsync(f => f.Id == id);

        if (entity != null)
            _peopleRegistrationDB.DbContext.Set<TEntity>().Remove(entity);

        return await _peopleRegistrationDB.DbContext.SaveChangesAsync();
    }

}