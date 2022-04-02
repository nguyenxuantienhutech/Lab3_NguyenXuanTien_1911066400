using Lab3_NguyenXuanTien_1911066400.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3_NguyenXuanTien_1911066400.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}