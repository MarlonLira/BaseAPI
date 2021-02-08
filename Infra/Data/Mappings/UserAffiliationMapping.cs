using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class UserAffiliationMapping : EntityTypeConfiguration<UserAffiliation>
    {
        public UserAffiliationMapping()
        {
            ToTable("user_affiliation")
                .HasKey(x => x.Id,
                        ix => ix.HasName("PK_IX_USER_AFFILIATION"));

            HasIndex(x => x.UserId)
              .HasName("FK_IX_USER__USER_AFFILIATION")
              .IsUnique()
              .IsClustered(false);

            HasIndex(x => x.ClientId)
                .HasName("FK_IX_CLIENT__USER_AFFILIATION")
                .IsUnique()
                .IsClustered(false);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Status)
                .HasColumnName("status")
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();

            Property(x => x.ClientId)
                .HasColumnName("clientId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.UserId)
                .HasColumnName("userId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            Property(x => x.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime");

            HasRequired(x => x.Client)
                .WithMany(x => x.UserAffiliations)
                .HasForeignKey(x => x.ClientId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.User)
               .WithMany(x => x.UserAffiliations)
               .HasForeignKey(x => x.UserId)
               .WillCascadeOnDelete(false);
        }
    }
}
