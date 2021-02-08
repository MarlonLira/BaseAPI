using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class CollaboratorMapping : EntityTypeConfiguration<Collaborator>
    {
        public CollaboratorMapping()
        {
            ToTable("collaborator")
                .HasKey(x => x.Id,
                        ix => ix.HasName("PK_IX_COLLABORATOR"));

            HasIndex(x => x.ClientId)
                .HasName("FK_IX_CLIENT__COLLABORATOR")
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
                .HasMaxLength(12)
                .IsRequired();

            Property(x => x.Password)
                .HasColumnName("password")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(x => x.ClientId)
                .HasColumnName("clientId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Image)
                .HasColumnName("image")
                .HasColumnType("varbinary(max)");

            Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            Property(x => x.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime");

            HasRequired(x => x.Client)
                .WithMany(x => x.Collaborators)
                .HasForeignKey(x => x.ClientId)
                .WillCascadeOnDelete(false);
        }
    }
}
