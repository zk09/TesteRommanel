using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.IO.Rommanel.Infra.Data.Extensions;

namespace User.IO.Rommanel.Infra.Data.Mapping
{
    public class UserMapping : EntityTypeConfiguration<Domain.Users.User>
    {
        public override void Map(EntityTypeBuilder<Domain.Users.User> builder)
        {


            builder
            .ToTable("Usuarios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.Email)
                   .HasColumnType("varchar(250)")
                   .IsRequired();

            builder.Property(e => e.DateBirth)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(e => e.Cpf)
                   .HasColumnType("varchar(50)")
                   .IsRequired();

            builder.Property(e => e.City)
               .HasColumnType("varchar(150)")
               .IsRequired();


            builder.Property(e => e.State)
               .HasColumnType("varchar(150)")
               .IsRequired();


            builder.Property(e => e.ZipCode)
               .HasColumnType("varchar(8)")
               .IsRequired();

            builder
            .Ignore(e => e.ValidationResult);

            builder
            .Ignore(e => e.CascadeMode);

        }
    }
}
