using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SonsuzBilgiV2.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Mvc.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
