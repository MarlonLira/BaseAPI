using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("user")
                .HasKey(x => x.Id,
                        ix => ix.HasName("PK_IX_USER"));

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Active)
                .HasColumnName("active")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.RegistryCode)
                .HasColumnName("registryCode")
                .HasColumnType("varchar")
                .HasMaxLength(12)
                .IsRequired();

            Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Password)
                .HasColumnName("password")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.Image)
                .HasColumnName("image")
                .HasColumnType("varbinary(max)");

            Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            Property(x => x.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime");

            HasMany(x => x.UserAffiliations)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
