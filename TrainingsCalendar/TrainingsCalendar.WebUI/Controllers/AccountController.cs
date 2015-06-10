using System.Web.Mvc;
using TrainingsCalendar.WebUI.Infrastructure.Abstract;
using TrainingsCalendar.WebUI.Models;

namespace TrainingsCalendar.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        readonly IAuthProvider _authProvider;
        public AccountController(IAuthProvider auth)
        {
            _authProvider = auth;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("AdminPanel", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
	}
}
