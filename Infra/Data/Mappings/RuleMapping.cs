using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class RuleMapping : EntityTypeConfiguration<Rule>
    {
        public RuleMapping()
        {
            ToTable("rule")
                .HasKey(x => x.Id,
                        ix => ix.HasName("PK_IX_RULE"));

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
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Level)
                .HasColumnName("level")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            Property(x => x.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime");

            HasMany(x => x.Employees)
               .WithRequired(x => x.Rule)
               .HasForeignKey(x => x.RuleId)
               .WillCascadeOnDelete(false);

        }
    }
}
