using SonsuzbilgiV2.Shared.Data.Abstract;
using SonsuzBilgiV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Data.Abstract
{
    public interface ICategoryRepository:IEntityRepository<Category>
    {
    }
}
