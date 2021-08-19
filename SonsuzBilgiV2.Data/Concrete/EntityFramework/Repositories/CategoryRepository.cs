using Microsoft.EntityFrameworkCore;
using SonsuzbilgiV2.Shared.Concrete.EntityFramework;
using SonsuzBilgiV2.Data.Abstract;
using SonsuzBilgiV2.Data.Concrete.EntityFramework.Contexts;
using SonsuzBilgiV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Data.Concrete.EntityFramework.Repositories
{
    public class CategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext Context) : base(Context)
        {
        }
        public async Task<Category> GetById(int id)
        {
            return await sonsuzBilgiV2Context.Categories.SingleOrDefaultAsync(x => x.Id == id);
        }
        private  SonsuzBilgiV2Context sonsuzBilgiV2Context 
        { get
            {
                return _Context as SonsuzBilgiV2Context;
            } 
        }
    }
}
