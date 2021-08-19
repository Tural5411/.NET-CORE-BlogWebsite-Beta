using Microsoft.AspNetCore.Identity;
using SonsuzbilgiV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Entities.Concrete
{
    public class User:IdentityUser<int>//Buradaki int primary key tipini int etmeyimizdir
    {
        public string Picture { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
