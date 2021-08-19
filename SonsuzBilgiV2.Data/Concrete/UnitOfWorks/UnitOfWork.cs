using SonsuzBilgiV2.Data.Abstract;
using SonsuzBilgiV2.Data.Abstract.UnitOfWorks;
using SonsuzBilgiV2.Data.Concrete.EntityFramework.Contexts;
using SonsuzBilgiV2.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Data.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SonsuzBilgiV2Context _context;
        private  ArticleRepository _articleRepository;
        private  CommentRepository _commentRepository;
        private CategoryRepository _categoryRepository;
        public UnitOfWork(SonsuzBilgiV2Context context)
        {
            _context = context;
        }
        // Article istenilen zaman _articleRepostory return edirik ancaq repostory null idise yeni repostr return edirik
        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new CommentRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
