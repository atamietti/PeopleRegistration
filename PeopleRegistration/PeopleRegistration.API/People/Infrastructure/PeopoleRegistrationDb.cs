using Microsoft.EntityFrameworkCore;
using PeopleRegistration.Shared.Domain;
using PeopleRegistration.Shared.Domain.Interfaces;

namespace PeopleRegistration.Infrastructure;

public class PeopoleRegistrationDb : DbContext, IPeopleRegistrationDb
{
    private readonly PeopoleRegistrationConfiguration _configuration;
    public DbContext DbContext => this;

    public PeopoleRegistrationDb(DbContextOptions<PeopoleRegistrationDb> options,
        PeopoleRegistrationConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.PeopoleRegistrationDBContext);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonBuild());
        modelBuilder.ApplyConfiguration(new AddressBuild());
        modelBuilder.ApplyConfiguration(new PersonBuild());

        base.OnModelCreating(modelBuilder);
    }
}
