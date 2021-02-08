using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public EmployeeMapping()
        {
            ToTable("employee")
                .HasKey(x => x.Id,
                        ix => ix.HasName("PK_IX_EMPLOYEE"));

            HasIndex(x => x.PartnerId)
               .HasName("FK_IX_PARTNER__EMPLOYEE")
               .IsUnique()
               .IsClustered(false);

            HasIndex(x => x.RuleId)
                .HasName("FK_IX_RULE__EMPLOYEE")
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

            Property(x => x.Image)
                .HasColumnName("image")
                .HasColumnType("varbinary(max)");

            Property(x => x.PartnerId)
                .HasColumnName("partnerId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.RuleId)
                .HasColumnName("ruleId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            Property(x => x.UpdatedAt)
                .HasColumnName("updatedAt")
                .HasColumnType("datetime");

            HasRequired(x => x.Partner)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.PartnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Rule)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.RuleId)
                .WillCascadeOnDelete(false);
        }
    }
}
