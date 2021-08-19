using SonsuzbilgiV2.Shared.Entities.Abstract;
using SonsuzBilgiV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Entities.DTOs
{
    public class UserListDto:DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
