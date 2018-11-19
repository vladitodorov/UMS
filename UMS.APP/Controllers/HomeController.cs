namespace UMS.APP.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using UMS.Models.ViewModels.AdUsers;
    using UMS.Services;

    public class HomeController : BaseController
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        public ActionResult Index()
        {
            //IEnumerable<AdAccountViewModel> adAccounts = this.service.GetAllAdAccounts();
            //return this.View(adAccounts);
            return View();
        }

    }
}