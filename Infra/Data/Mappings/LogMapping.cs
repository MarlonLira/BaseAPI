using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class LogMapping : EntityTypeConfiguration<Log>
    {
        public LogMapping()
        {
            ToTable("log")
                .HasKey(x => x.Id,
                        ix => ix.HasName("PK_IX_LOG"));

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Level)
                .HasColumnName("level")
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();

            Property(x => x.Message)
                .HasColumnName("message")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            Property(x => x.Source)
                .HasColumnName("source")
                .HasColumnType("varchar(max)");

            Property(x => x.Code)
                .HasColumnName("code")
                .HasColumnType("varchar")
                .HasMaxLength(3);

            Property(x => x.CreatedAt)
                .HasColumnName("createdAt")
                .HasColumnType("datetime");
        }
    }
}
