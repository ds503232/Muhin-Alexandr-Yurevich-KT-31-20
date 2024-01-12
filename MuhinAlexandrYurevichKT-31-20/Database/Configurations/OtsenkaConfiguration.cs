using MuhinAlexandrYurevichKT_31_20.Database.Helpers;
using MuhinAlexandrYurevichKT_31_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MuhinAlexandrYurevichKT_31_20.Database.Configurations
{
    public class OtsenkaConfiguration : IEntityTypeConfiguration<Otsenka>
    {
        private const string TableName = "cd_otsenka";

        public void Configure(EntityTypeBuilder<Otsenka> builder)
        {
            builder
                .HasKey(p => p.OtsenkaId)
                .HasName($"pk_{TableName}_otsenka_id");

            builder.Property(p => p.OtsenkaId)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.OtsenkaId)
                .HasColumnName("otsenka_id")
                .HasComment("ID оценки");

            builder.Property(p => p.Mark)
                .IsRequired()
                .HasColumnName("c_otsenka_mark")
                .HasColumnType(ColumnType.Int).HasMaxLength(10)
                .HasComment("Оценка");

            builder.Property(p => p.StudentId)
                .IsRequired()
                .HasColumnName("f_student_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID студента");

            builder.ToTable(TableName)
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .HasConstraintName("fk_f_student_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(TableName)
                .HasIndex(p => p.StudentId, $"idx_{TableName}_fk_f_student_id");

            builder.Navigation(p => p.Student)
                .AutoInclude();

            builder.Property(p => p.SubjectId)
                .IsRequired()
                .HasColumnName("f_subject_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("ID предмета");

            builder.ToTable(TableName)
                .HasOne(p => p.Subject)
                .WithMany()
                .HasForeignKey(p => p.SubjectId)
                .HasConstraintName("fk_f_subject_id")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable(TableName)
                .HasIndex(p => p.SubjectId, $"idx_{TableName}_fk_f_subject_id");

            builder.Navigation(p => p.Subject)
                .AutoInclude();
        }
    }
}
