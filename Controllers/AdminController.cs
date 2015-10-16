using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ssc.consulting.switchboard.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        [Route("")]
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("IsLoggedIn");
            return Redirect("/Auth/Login");
        }
	}
}