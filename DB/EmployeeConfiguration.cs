using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using WorkConsole.Model;

namespace WorkConsole.DB
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.Property(x => x.Id)
            .UseIdentityColumn()
            .UseSerialColumn()
            .IsRequired()
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
            .IsRequired()
            .HasColumnName("FirstName");

            builder.Property(x => x.LastName)
            .IsRequired()
            .HasColumnName("LastName");

            builder.Property(x => x.SecondName)
            .IsRequired()
            .HasColumnName("SecondName");

            builder.Property(x => x.Gender)
            .IsRequired()
            .HasColumnName("Gender");

            builder.Property(x => x.BirthDate)
            .IsRequired()
            .HasColumnType("timestamp")
            .HasColumnName("BirthDate");
        }
    }
}
