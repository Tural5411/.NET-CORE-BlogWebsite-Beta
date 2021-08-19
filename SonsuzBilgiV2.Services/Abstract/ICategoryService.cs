using SonsuzbilgiV2.Shared.Utilities.Results.Abstract;
using SonsuzBilgiV2.Entities.Concrete;
using SonsuzBilgiV2.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryUpdateDto>> GetUpdateDto(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllByNonDelete();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName);
        Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto,string modifiedByName);
        Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName);
        Task<IResult> HardDelete(int categoryId);
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByNonDeleted();

    }
}
