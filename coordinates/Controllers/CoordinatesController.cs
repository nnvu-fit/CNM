using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace coordinates.Controllers
{
    public class CoordinatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}