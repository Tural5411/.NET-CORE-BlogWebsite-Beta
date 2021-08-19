using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonsuzBilgiV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasMaxLength(70).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Note).HasMaxLength(500).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.ToTable("Categories");

            builder.HasData(new Category
            {
                Id = 1,
                Name = "C#",
                Description = "C# Programlasdirma ile bagli en yeni meqaleler",
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Note = "C# blog categoriyasi",
            },
            new Category 
            {
                Id = 2,
                Name = "C++",
                Description = "C++ Programlasdirma ile bagli en yeni meqaleler",
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Note = "C++ blog categoriyasi",
            },
            new Category
            {
                Id = 3,
                Name = "JavaScript",
                Description = "JavaScript Programlasdirma ile bagli en yeni meqaleler",
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                ModifiedDate = DateTime.Now,
                Note = "JavaScript blog categoriyasi",
            });
        }
    }
}
