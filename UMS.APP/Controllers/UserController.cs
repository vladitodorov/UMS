namespace UMS.APP.Controllers
{
    using System.Web.Mvc;
    using UMS.Models.ViewModels.AdAccount;
    using UMS.Services;

    public class UserController : Controller
    {
        private UserServices service;

        public UserController()
        {
            this.service = new UserServices();
        }

        // GET: User
        public ActionResult Details(int id)
        {
            AdAccountSingleViewModel account = this.service.GetAccountDetails(id);

            if (account == null)
            {
                return this.HttpNotFound();
            }

            return View(account);
        }
    }
}