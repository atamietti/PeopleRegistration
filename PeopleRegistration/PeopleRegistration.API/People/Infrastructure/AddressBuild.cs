using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleRegistration.Domain.Entities;

namespace PeopleRegistration.Infrastructure;

public class AddressBuild : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address));

        builder.Property(e => e.PersonId)
            .HasColumnName("personId")
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.Street)
           .HasColumnName("street")
           .HasColumnType("varchar(255)");

        builder.Property(e => e.City)
           .HasColumnName("city")
           .HasColumnType("varchar(255)");

        builder.Property(e => e.PostalCode)
           .HasColumnName("postalCode")
           .HasColumnType("varchar(10)");

        builder.Property(e => e.Region)
           .HasColumnName("region")
           .HasColumnType("varchar(255)");

        builder.Property(e => e.Country)
           .HasColumnName("country")
           .HasColumnType("varchar(255)");

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

    }
}
