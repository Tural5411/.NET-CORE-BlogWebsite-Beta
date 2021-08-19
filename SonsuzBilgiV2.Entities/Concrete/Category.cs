using SonsuzbilgiV2.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Entities.Concrete
{
    public class Category:EntityBase,IEntity
    {
        public string Name{ get; set; }
        public string Description { get; set; }
        //Bir Kateqoriya birden cox meqaleye sahib ola biler
        public ICollection<Article> Articles { get; set; } 
    }
}
