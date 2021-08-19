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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).HasMaxLength(600).IsRequired();

            builder.Property(c => c.Note).HasMaxLength(500).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.HasOne<Article>(a => a.Article).WithMany(a => a.Comments)
                .HasForeignKey(a => a.ArticleId);

            builder.ToTable("Comments");

            //builder.HasData(new Comment
            //{
            //    Id = 1,
            //    ArticleId = 1,
            //    Text = "Ben bir primatım. Maymunlar da primattır,C# ",
            //    CreatedByName = "InitialCreate",
            //    ModifiedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    ModifiedDate = DateTime.Now,
            //    Note = "C# komenti",
            //},
            //new Comment
            //{
            //    Id = 2,
            //    ArticleId = 2,
            //    Text = "Ben bir c++. Maymunlar da c+++ ",
            //    CreatedByName = "InitialCreate",
            //    ModifiedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    ModifiedDate = DateTime.Now,
            //    Note = "C++ komenti",
            //},
            //new Comment
            //{
            //    Id = 3,
            //    ArticleId = 3,
            //    Text = "Ben bir javasciprt. akrabalarımızdır. ",
            //    CreatedByName = "InitialCreate",
            //    ModifiedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    ModifiedDate = DateTime.Now,
            //    Note = "JS komenti",
            //});
        }
    }
}
