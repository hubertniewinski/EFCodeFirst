using EFCodeFirst.Repositories.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCodeFirst.Repositories.Configurations;

public class DoctorConfiguration : PersonConfiguration<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> builder)
    {
        base.Configure(builder);
        builder.HasKey(x => x.IdDoctor);
        builder.Property(x => x.IdDoctor).ValueGeneratedOnAdd().IsRequired();
        builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
    }
}