using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleRegistration.Domain.Entities;

namespace PeopleRegistration.Infrastructure;

public class PersonBuild : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable(nameof(Person));

        builder.HasMany(f => f.Addresses)
            .WithOne().HasForeignKey(f => f.PersonId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasMany(f => f.Phones)
           .WithOne().HasForeignKey(f => f.PersonId)
           .OnDelete(DeleteBehavior.Cascade)
           .IsRequired(false);

        builder.Property(e => e.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(255)")
            .IsRequired(true)
            .HasMaxLength(255);

        builder.Property(e => e.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(255)")
            .IsRequired(true)
            .HasMaxLength(255);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.HasIndex(e => e.Email).IsUnique();
        builder.Navigation(e => e.Addresses).AutoInclude();
        builder.Navigation(e => e.Phones).AutoInclude();

    }
}
