using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (base.Request.AcceptTypes != null && base.Request.AcceptTypes.Any(x => x == "text/html"))
            {
                return View();
            }

            return Redirect("https://raw.githubusercontent.com/motowilliams/psake-surgeon/master/init.ps1");
        }
    }
}