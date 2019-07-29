using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Course.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return Content("Sono Index");
        }

        public IActionResult Detail(string id)
        {
            return Content($"Sono Detail con id {id}");
        }
    }
}