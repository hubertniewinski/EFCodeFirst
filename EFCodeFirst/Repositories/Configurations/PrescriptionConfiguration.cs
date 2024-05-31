using EFCodeFirst.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.Repositories.Configurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(x => x.IdPrescription);
        builder.HasOne(x => x.Patient)
            .WithMany(x => x.Prescriptions)
            .HasForeignKey(x => x.IdPatient);
        builder.HasOne(x => x.Doctor)
            .WithMany()
            .HasForeignKey(x => x.IdDoctor);
        builder.Property(x => x.IdPrescription).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.IdPatient).IsRequired();
        builder.Property(x => x.IdDoctor).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.DueDate).IsRequired();
    }
}