using MuhinAlexandrYurevichKT_31_20.Database.Helpers;
using MuhinAlexandrYurevichKT_31_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuhinAlexandrYurevichKT_31_20.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        private const string TableName = "cd_subject";

        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(p => p.SubjectId)
                .HasName($"pk_{TableName}_subject_id");

            builder.Property(p => p.SubjectId)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.SubjectId)
                .HasColumnName("subject_id")
                .HasComment("ID предмета");

            builder.Property(p => p.SubjectName)
                .IsRequired()
                .HasColumnName("c_subject_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название предмета");

            builder.ToTable(TableName);
        }
    }
}
