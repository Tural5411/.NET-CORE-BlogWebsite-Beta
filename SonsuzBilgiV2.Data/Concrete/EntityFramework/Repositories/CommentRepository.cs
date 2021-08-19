using Microsoft.EntityFrameworkCore;
using SonsuzbilgiV2.Shared.Concrete.EntityFramework;
using SonsuzBilgiV2.Data.Abstract;
using SonsuzBilgiV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Data.Concrete.EntityFramework.Repositories
{
    public class CommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext Context) : base(Context)
        {
        }
    }
}
