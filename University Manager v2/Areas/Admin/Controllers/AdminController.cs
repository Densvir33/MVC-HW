using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Manager_v2.Models;
using University_Manager_v2.Models.Entity.Models;

namespace University_Manager_v2.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Admin/Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllGroups()
        {
            IEnumerable<GroupViewModels> models = _context.Groups.Select(m => new GroupViewModels
            {
                Id = m.Id,
                Name = m.Name
            });
            return View(models);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student St = _context.Students.Find(id);
            StudentViewModel model = new StudentViewModel()
            {

                Id = St.Id,
                Name = St.Name,
                Image = St.Image
            };
            return View(model);


        }
        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {

            Student St = _context.Students.Find(model.Id);
            St.Id = model.Id;
            St.Name = model.Name;
            St.Image = model.Image;
            
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }


        public ActionResult Delete(int id)
        {
            Student St = _context.Students.Find(id);

            _context.Students.Remove(St);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public ActionResult AddGroup()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddGroup(GroupViewModels model)
        {
            if (model != null)
            {
                Group group = new Group()
                {
                    Name = model.Name
                };
                _context.Groups.Add(group);
                _context.SaveChanges();
            }
            return RedirectToAction("GetAllGroups");
        }
    }
}