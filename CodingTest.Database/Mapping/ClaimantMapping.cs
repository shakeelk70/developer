using CodingTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingTest.Database.Mapping;

public class ClaimantMapping : IEntityTypeConfiguration<Claimant>
{
    public void Configure(EntityTypeBuilder<Claimant> builder)
    {
        builder.HasKey(c => c.Id).HasName("ClaimantId");
        builder.Property(c => c.FamilyName).IsUnicode(true).IsRequired(true).HasMaxLength(50);
        builder.Property(c => c.GivenName).IsUnicode(true).IsRequired(false).HasMaxLength(50);
        builder.Property(c => c.MiddleName).IsUnicode(true).IsRequired(false).HasMaxLength(50);
        builder.Property(c => c.Mobile).IsUnicode(false).HasMaxLength(10);
        builder.Property(c => c.Email).IsUnicode(false).IsRequired(true).HasMaxLength(50);
        builder.HasOne(c => c.Company);
        builder.Property(c => c.DateOfBirth).IsRequired(true);
    }
}