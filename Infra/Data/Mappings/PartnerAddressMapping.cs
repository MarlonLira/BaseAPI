using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class PartnerAddressMapping : EntityTypeConfiguration<PartnerAddress>
    {
        public PartnerAddressMapping()
        {
            ToTable("partner_address")
                .HasKey(x => x.Id,
                        ix => ix.HasName("PK_IX_PARTNER_ADDRESS"));

            HasIndex(x => x.PartnerId)
                .HasName("FK_IX_PARTNER__PARTNER_ADDRESS")
                .IsUnique()
                .IsClustered(false);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Active)
                .HasColumnName("active")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.Country)
                .HasColumnName("country")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.State)
                .HasColumnName("state")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.City)
                .HasColumnName("city")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Street)
                .HasColumnName("street")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Number)
                .HasColumnName("number")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(x => x.ZipCode)
                .HasColumnName("zipCode")
                .HasColumnType("varchar")
                .HasMaxLength(9)
                .IsRequired();

            Property(x => x.Latitude)
                .HasColumnName("latitude")
                .HasColumnType("float")
                .IsRequired();

            Property(x => x.Longitude)
                .HasColumnName("longitude")
                .HasColumnType("float")
                .IsRequired();

            Property(x => x.Complement)
                .HasColumnName("complement")
                .HasColumnType("varchar")
                .HasMaxLength(50);

            Property(x => x.PartnerId)
                .HasColumnName("partnerId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            Property(x => x.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime");

            HasRequired(x => x.Partner)
                .WithMany(x => x.PartnerAddresses)
                .HasForeignKey(x => x.PartnerId)
                .WillCascadeOnDelete(false);

        }
    }
}
