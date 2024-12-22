using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleRegistration.Domain.Entities;

namespace PeopleRegistration.Infrastructure;

public class PhoneBuild : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable(nameof(Phone));

        builder.Property(e => e.PersonId)
            .HasColumnName("personId")
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.PhoneNumber)
            .HasColumnName("phoneNumber")
            .HasColumnType("varchar(20)")
            .IsRequired(true)
            .HasMaxLength(20);

        builder.Property(e => e.CountryCode)
            .HasColumnName("countryCode")
            .HasColumnType("varchar(5)")
            .IsRequired(true)
            .HasMaxLength(5);

        builder.Property(e => e.IsPrimary)
            .HasColumnName("isPrimary")
            .HasColumnType("bit");

        builder.Property(e => e.IsVerified)
            .HasColumnName("isVerified")
            .HasColumnType("bit");

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
