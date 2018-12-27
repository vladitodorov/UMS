namespace UMS.APP.Controllers
{
    using System.Web.Mvc;
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
            var result = service.GetAllReqForProfiling();
            return View(result);
        }

    }
}