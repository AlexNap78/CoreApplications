using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Models.Services.Application;
using Course.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Course.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        public IActionResult Index()
        {
            
            List<CourseViewModel> courses = courseService.GetCourses();
            return View(courses);
        }

        public IActionResult Detail(int id)
        {
           
            CourseDetailViewModel course = courseService.GetCourse(id);

            return View(course);
        }
    }
}