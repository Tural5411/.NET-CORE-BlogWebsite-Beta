using SonsuzbilgiV2.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzbilgiV2.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;} //ResultStatus.Succes
        public string Message { get;}
        public Exception Exception { get;}
    }
}
