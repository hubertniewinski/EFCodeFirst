using EFCodeFirst.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.Repositories.Configurations;

public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(x => new { x.IdMedicament, x.IdPrescription });
        builder.HasOne(x => x.Prescription)
            .WithMany(x => x.PrescriptionMedicaments)
            .HasForeignKey(x => x.IdPrescription);
        builder.HasOne(x => x.Medicament)
            .WithMany()
            .HasForeignKey(x => x.IdMedicament);
        builder.Property(x => x.IdMedicament).IsRequired();
        builder.Property(x => x.IdPrescription).IsRequired();
        builder.Property(x => x.Dose);
        builder.Property(x => x.Details).HasMaxLength(100).IsRequired();
    }
}