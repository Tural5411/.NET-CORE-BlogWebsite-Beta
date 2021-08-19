using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SonsuzBilgiV2.Data.Abstract.UnitOfWorks;
using SonsuzBilgiV2.Data.Concrete.EntityFramework.Contexts;
using SonsuzBilgiV2.Data.Concrete.UnitOfWorks;
using SonsuzBilgiV2.Entities.Concrete;
using SonsuzBilgiV2.Services.Abstract;
using SonsuzBilgiV2.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection,string connectionString)
        {
            //AddScoped = Her request yarandiqda yeni bir instance yaranir ve bir request icersinde sadece bir dene obyekt istfd olunur
            //Transient = Her obyekt cagirisinda yeni bir instance yaradir,Scopedde ise sadece Request zamani 1defe yaranir
            serviceCollection.AddDbContext<SonsuzBilgiV2Context>(options=>options.UseSqlServer(connectionString));
            serviceCollection.AddIdentity<User, Role>(options => {
                //User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                //User UserName and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<SonsuzBilgiV2Context>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();

            return serviceCollection;
        }
    }
}
