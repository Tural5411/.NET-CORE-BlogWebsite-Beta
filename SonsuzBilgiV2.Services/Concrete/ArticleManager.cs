using AutoMapper;
using SonsuzbilgiV2.Shared.Utilities.Results.Abstract;
using SonsuzbilgiV2.Shared.Utilities.Results.ComplexTypes;
using SonsuzbilgiV2.Shared.Utilities.Results.Concrete;
using SonsuzBilgiV2.Data.Abstract.UnitOfWorks;
using SonsuzBilgiV2.Entities.Concrete;
using SonsuzBilgiV2.Entities.DTOs;
using SonsuzBilgiV2.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Services.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticleManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(ArticleAddDto articleAddDto, string createdByName)
        {
            var article = _mapper.Map<Article>(articleAddDto);
            article.CreatedByName = createdByName;
            article.ModifiedByName = createdByName;
            article.UserId = 1;
            await _unitOfWork.Articles.AddAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Succes, $"{articleAddDto.Title} adli meqale ugurla elave edildi");
        }

        public async Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);
                article.ModifiedByName = modifiedByName;
                article.ModifiedDate = DateTime.Now;
                article.IsDeleted = true;

                await _unitOfWork.Articles.UpdateAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Succes, message: $"{article.Title} adli meqale ugurla silindi");
            }
            else
            {
                return new Result(ResultStatus.Error, message: $"Bu cur meqale tapilmadi");
            }
        }

        public async Task<IResult> HardDelete(int articleId)
        {
            var result = await _unitOfWork.Articles.AnyAsync(a => a.Id == articleId);
            if (result)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);

                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Succes, message: $"{article.Title} adli meqale ugurla databazadan silindi");
            }
            else
            {
                return new Result(ResultStatus.Error, message: $"Bu cur meqale tapilmadi");
            }
        }

        public async Task<IResult> Update(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            // Article tipinde return almaq isteyirik,bu prosesin qaynagida articleUpdateDtodan gelir
            var article = _mapper.Map<Article>(articleUpdateDto);
            article.ModifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Succes, $"{articleUpdateDto.Title} adli meqale ugurla edit edildi");
        }
        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId,a=>a.User,a=>a.Category);
            if (article != null)
            {
                return new DataResult<ArticleDto>(ResultStatus.Succes, new ArticleDto
                {
                    Article = article,
                    ResultStatus=ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ArticleDto>(ResultStatus.Error, message: "Məqalə tapılmadı.", null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAll()
        {
            var articles =await _unitOfWork.Articles.GetAllAsync(null,a => a.Category);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Məqalə tapılmadı", null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c=>c.Id==categoryId);
            var Booleanresult = Convert.ToBoolean(result);
            if (Booleanresult)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(c => c.CategoryId == categoryId
                               && c.IsActive && !c.IsDeleted, a => a.Category, a => a.User);
                if (articles.Count > -1)
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                    {
                        Articles = articles,
                        ResultStatus = ResultStatus.Succes
                    });
                }
                else
                {
                    return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Məqalə tapılmadı", null);
                }
            }
            else
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Kateqoriya tapılmadı", null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNonDeletedAndActive()
        {
            var articles=  await _unitOfWork.Articles.GetAllAsync(a=>!a.IsDeleted &&
                a.IsActive, a => a.Category, a => a.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus = ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Məqalə tapılmadı", null);
            }
        }

        public async Task<IDataResult<ArticleListDto>> GetByNonDeleted()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => !a.IsDeleted, a => a.Category, a => a.User);
            if (articles.Count > -1)
            {
                return new DataResult<ArticleListDto>(ResultStatus.Succes, new ArticleListDto
                {
                    Articles = articles,
                    ResultStatus=ResultStatus.Succes
                }) ;
            }
            else
            {
                return new DataResult<ArticleListDto>(ResultStatus.Error, message: "Məqalə tapılmadı", null);
            }
        }

        public async Task<IDataResult<int>> Count()
        {
            var articleCount = await _unitOfWork.Articles.CountAsync(x=>x.IsActive);
            if (articleCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, articleCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Xəta baş verdi", -1);
        }

        public async Task<IDataResult<int>> CountByNonDeleted()
        {
            var articlesCount = await _unitOfWork.Articles.CountAsync(c => !c.IsDeleted);
            if (articlesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, articlesCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Xəta baş verdi", -1);
        }
    }
}
