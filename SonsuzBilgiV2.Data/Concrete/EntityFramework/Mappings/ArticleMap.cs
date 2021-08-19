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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//Identity

            builder.Property(a => a.Title).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(60).IsRequired();
            builder.Property(a => a.SeoDescription).HasMaxLength(300).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70).IsRequired();
            builder.Property(a => a.ThumbNail).HasMaxLength(300).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(
                a => a.CategoryId);

            //Bir meqalenin 1 useri olur,     1 user birden cox meqaleye sahib ola biler (one to many)
            builder.HasOne<User>(u => u.User).WithMany(u => u.Articles).HasForeignKey(
                u => u.UserId);

            builder.ToTable("Articles");

            //builder.HasData(new Article
            //{
            //    Id = 1,
            //    CategoryId = 1,
            //    UserId = 1,
            //    Title = "C# 9.0 Yeni Gelen Xususiyyetler",
            //    Content = "Lorem Ipsum, dizgi ve ılık yazılımları ile popüler olmuştur.",
            //    ThumbNail = "Default.Jpg",
            //    SeoAuthor = "Tural Abdulxaliqov",
            //    SeoDescription = "C# 9.0 Yeni Gelen Xususiyyetler",
            //    SeoTags = "C#,C# 9,NET CORE 5",
            //    CommentCount = 71,
            //    ViewsCount = 21,
            //    Date = DateTime.Now,
            //    CreatedByName = "InitialCreate",
            //    ModifiedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    ModifiedDate = DateTime.Now,
            //    Note = "c# yenilikleri",
            //},
            //new Article
            //{
            //    Id = 2,
            //    CategoryId = 2,
            //    UserId = 1,
            //    Title = "C++ Yeni Xususiyetler",
            //    Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde.",
            //    ThumbNail = "Default.Jpg",
            //    SeoAuthor = "Tural Abdulxaliqov",
            //    SeoDescription = "C++  Yeni Gelen Xususiyyetler",
            //    SeoTags = "C++,C# 9,NET CORE 5",
            //    CommentCount = 12,
            //    ViewsCount = 11,
            //    Date = DateTime.Now,
            //    CreatedByName = "InitialCreate",
            //    ModifiedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    ModifiedDate = DateTime.Now,
            //    Note = "C++ yenilikleri",
            //},
            //new Article
            //{
            //    Id = 3,
            //    CategoryId = 3,
            //    UserId = 1,
            //    Title = "Java Script Yenilikleri",
            //    Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir.",
            //    ThumbNail = "Default.Jpg",
            //    SeoAuthor = "Tural Abdulxaliqov",
            //    SeoDescription = "JavaScript Yeni Gelen Xususiyyetler",
            //    SeoTags = "JavaScript,Js",
            //    CommentCount = 31,
            //    ViewsCount = 15,
            //    Date = DateTime.Now,
            //    CreatedByName = "InitialCreate",
            //    ModifiedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    ModifiedDate = DateTime.Now,
            //    Note = "JS yenilikleri",
            //});
        }
    }
}
