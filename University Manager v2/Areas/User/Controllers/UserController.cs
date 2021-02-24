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
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        // GET: User/User
        public ActionResult HomePage()
        {
            IEnumerable<GroupViewModels> models = ctx.Groups.Select(m => new GroupViewModels()
            {
                Id = m.Id,
                Name = m.Name
            });
            return View(models);
        }

        public ActionResult SentRequest(string name)
        {
            var user = ctx.Users.Find(User.Identity.GetUserId());
            if (user.Student.Group == null)
            {
                user.Student.Group = ctx.Groups.FirstOrDefault(x => x.Name == name);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            ctx.Groups.Remove(ctx.Groups.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(GroupViewModels pt)
        {
            ctx.Groups.Add(new Group
            {
                Name = pt.Name
            });
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Group p = ctx.Groups.Find(id);
            GroupViewModels model = new GroupViewModels()
            {
                Id = p.Id,
                Name = p.Name
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(GroupViewModels pt)
        {
            Group p = ctx.Groups.Find(pt.Id);
            p.Name = pt.Name;
            ctx.SaveChanges();
            return RedirectToAction("Index");
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
            var user = ctx.Users.Find(Id);
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
