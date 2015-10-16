using System.Web.Mvc;
using System.Web.Security;
using ssc.consulting.switchboard.ViewModels;

namespace ssc.consulting.switchboard.Controllers
{
    [RoutePrefix("Admin/Login")]
    public class LoginController : Controller
    {
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.PassWord.Equals("@tuvanduhoc@123") && model.UserName.Equals("administrator"))
                {
                    Session["IsLoggedIn"] = true;
                    return Redirect("/Admin");
                }

                return RedirectToAction("Login", "Auth");

            }

            Session["IsLoggedIn"] = false;
            return RedirectToAction("Login", "Auth");
        }
    }
}