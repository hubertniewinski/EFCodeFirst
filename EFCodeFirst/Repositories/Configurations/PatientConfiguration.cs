using EFCodeFirst.Repositories.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.Repositories.Configurations;

public class PatientConfiguration : PersonConfiguration<Patient>
{
    public override void Configure(EntityTypeBuilder<Patient> builder)
    {
        base.Configure(builder);
        builder.HasKey(x => x.IdPatient);
        builder.Property(x => x.IdPatient).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Birthdate).IsRequired();
    }
}