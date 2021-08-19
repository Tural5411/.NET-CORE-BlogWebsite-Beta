using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzbilgiV2.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        public T Data { get;} //new DataResult<Category>(ResultStatus.Succes,Category)
                             //new DataResult<IList<Category>>(ResultStatus.Succes,CategoryList)
    }
}
