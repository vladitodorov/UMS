namespace UMS.APP.Controllers
{
    using System.Web.Mvc;
    using UMS.Models.ViewModels.AdUsers;
    using UMS.Models.ViewModels.Users;
    using UMS.Services;

    public class UsersController : Controller
    {
        private UserServices service;

        public UsersController()
        {
            this.service = new UserServices();
        }

        // GET: Users by EGN
        public ActionResult Result(string egn)
        {
            if (egn != string.Empty)
            {
                var egnLong = long.Parse(egn);

                AdUserByEgnViewModel user = this.service.GetUserByEgn(egnLong);

                if (user == null)
                {
                    ViewData["ErrorMessage"] = "Не е намерен потребител по търсеното ЕГН!";

                    return RedirectToAction("Index", "Home");
                }

                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: User information by EGN
        public ActionResult Details(string id)
        {
            var egnLong = long.Parse(id);

            AllUserDetailsByEgn userDetails = this.service.GetAllUserDetailsByEgn(egnLong);

            return View(userDetails);
        }
    }
}