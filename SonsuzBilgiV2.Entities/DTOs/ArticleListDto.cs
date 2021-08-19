using SonsuzbilgiV2.Shared.Entities.Abstract;
using SonsuzbilgiV2.Shared.Utilities.Results.ComplexTypes;
using SonsuzBilgiV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Entities.DTOs
{
    public class ArticleListDto:DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}
