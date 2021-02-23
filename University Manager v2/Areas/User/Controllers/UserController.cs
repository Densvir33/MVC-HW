using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University_Manager_v2.Areas.User.Controllers
{
    public class UserController : Controller
    {
        // GET: User/User
        public ActionResult HomePage()
        {
            return View();
        }
    }
}