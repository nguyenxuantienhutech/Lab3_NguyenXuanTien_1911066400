using Lab3_NguyenXuanTien_1911066400.Models;
using Lab3_NguyenXuanTien_1911066400.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3_NguyenXuanTien_1911066400.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        // Chỉ được áp dụng cho controller, Action của controller, Pagemodel
        //Để xác định ai được quyền truy cập vào
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Check spam request tới sever
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbContext.Attendances.Where(a => a.AttendeeId == userId).Select(a => a.Course).Include(l => l.Lecturer).Include(l => l.Category).ToList();
            var viewModel = new CoursesViewModel()
            {
                UpcommingCourses = courses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
    }
}