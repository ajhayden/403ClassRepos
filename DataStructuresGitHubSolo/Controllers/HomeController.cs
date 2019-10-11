using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresGitHubSolo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //This redirects to byu.edu
        public ActionResult Exit()
        {
            return Redirect("https://www.byu.edu");
        }
    }
}