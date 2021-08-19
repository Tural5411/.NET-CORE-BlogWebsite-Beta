using SonsuzbilgiV2.Shared.Entities.Abstract;
using SonsuzBilgiV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Entities.DTOs
{
    public class UserDto:DtoGetBase
    {
        public User User { get; set; }
    }
}
