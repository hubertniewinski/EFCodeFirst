using EFCodeFirst.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.Repositories.Configurations;

public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(x => x.IdMedicament);
        builder.Property(x => x.IdMedicament).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Type).HasMaxLength(100).IsRequired();
    }
}