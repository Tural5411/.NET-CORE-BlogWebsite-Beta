using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Data.Abstract.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        //Bu interfacelerin entity framework ile elaqesi yoxdur,ado net ve s ilede isleyir

        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }  //_unitOfWork.Categories.AddAsync()
        Task<int> SaveAsync();
    }
}
