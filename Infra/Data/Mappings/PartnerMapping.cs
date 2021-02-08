using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class PartnerMapping : EntityTypeConfiguration<Partner>
    {
        public PartnerMapping()
        {
            ToTable("partner")
                .HasKey(x => x.Id,
                        ix => ix.HasName("PK_IX_PARTNER"));

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

            Property(x => x.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar")
                .HasMaxLength(12);

            Property(x => x.About)
                .HasColumnName("about")
                .HasColumnType("varchar")
                .HasMaxLength(255);

            Property(x => x.Image)
                .HasColumnName("image")
                .HasColumnType("varbinary(max)");

            Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            Property(x => x.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime");

            HasMany(x => x.PartnerAddresses)
                .WithRequired(x => x.Partner)
                .HasForeignKey(x => x.PartnerId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Employees)
               .WithRequired(x => x.Partner)
               .HasForeignKey(x => x.PartnerId)
               .WillCascadeOnDelete(false);
        }
    }
}
