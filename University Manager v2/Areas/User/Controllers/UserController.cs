using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Manager_v2.Models;
using University_Manager_v2.Models.Entity.Models;

namespace University_Manager_v2.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: User/User
        public ActionResult HomePage()
        {
            IEnumerable<GroupViewModels> models = _context.Groups.Select(m => new GroupViewModels()
            {
                Id = m.Id,
                Name = m.Name
            });
            return View(models);
        }

        public ActionResult GetAllGroups()
        {
            var groups = _context.Groups.Select(x => new GroupViewModels
            {
                Id = x.Id,
                Name = x.Name,
            });
            return View(groups);
        }


        public ActionResult SendRequest(string groupName)
        {
            var user = _context.Users.Find(User.Identity.GetUserId());
            if (user.Student.Group == null)
            {
                user.Student.Group = _context.Groups.FirstOrDefault(x => x.Name == groupName);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Detail()
        {
            string Id = User.Identity.GetUserId();
            var user = _context.Users.Find(Id);
            var student = user.Student;
            StudentViewModel St = new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Image = student.Image
            };
            return View(St);
        }
    }
}
