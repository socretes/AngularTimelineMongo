using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Mvc;

namespace AngularServiceStackMongo.Web.Controllers
{
    public class HomeController : ServiceStackController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}