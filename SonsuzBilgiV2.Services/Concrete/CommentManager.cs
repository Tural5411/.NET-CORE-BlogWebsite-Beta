using SonsuzbilgiV2.Shared.Utilities.Results.Abstract;
using SonsuzbilgiV2.Shared.Utilities.Results.ComplexTypes;
using SonsuzbilgiV2.Shared.Utilities.Results.Concrete;
using SonsuzBilgiV2.Data.Abstract.UnitOfWorks;
using SonsuzBilgiV2.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Services.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IDataResult<int>> Count()
        {
            var commentCount = await _unitOfWork.Comments.CountAsync(x=>x.IsActive);
            if (commentCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, commentCount);
            }
            return new DataResult<int>(ResultStatus.Error,"Xəta baş verdi",-1);
        }

        public async Task<IDataResult<int>> CountByNonDeleted()
        {
            var commentCount = await _unitOfWork.Comments.CountAsync(c => !c.IsDeleted);
            if (commentCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, commentCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Xəta baş verdi", -1);
        }
    }
}
