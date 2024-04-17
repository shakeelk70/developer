using CodingTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingTest.Database.Mapping;

public class CompanyMapping : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c=> c.Id).HasName("CompanyId");
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.ABN).IsUnicode(false).HasMaxLength(10);
        builder.Property(c => c.ACN).IsUnicode(false).HasMaxLength(10);
        builder.Property(c => c.LegalName).IsUnicode(false).HasMaxLength(50);
        builder.Property(c => c.TradingName).IsUnicode(false).IsRequired().HasMaxLength(50);
        builder.OwnsMany(c => c.CompanyContacts, b => {
            b.HasKey(cc => cc.Id).HasName("CompanyContactId");
            b.Property(cc => cc.FamilyName).IsUnicode(true).IsRequired().HasMaxLength(50);
            b.Property(cc => cc.GivenName).IsUnicode(true).HasMaxLength(50);
            b.Property(cc => cc.Email).IsUnicode(false).IsRequired(true).HasMaxLength(50);
            b.Property(cc => cc.Mobile).IsUnicode(false).IsRequired(false).HasMaxLength(10);
        });
    }
}
