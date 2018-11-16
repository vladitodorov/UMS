namespace UMS.APP.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles = "Administrator")]
    public class AdministrationController : BaseController
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }
    }
}