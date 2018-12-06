namespace UMS.APP.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using UMS.Models.ViewModels.Menu;
    using UMS.Services;

    public class MenuController : BaseController
    {
        private MenuService service;

        public MenuController()
        {
            service = new MenuService();
        }

        // GET: Menu
        public ActionResult Index(int page=1)
        {
            AllProfileMenuViewModelPages listProfileMenus = service.GetAllProfileMenus(page);

            return View(listProfileMenus);
        }

        //GET 
        public ActionResult Add()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Add(AddProfileMenu model)
        {
            if (!ModelState.IsValid || model.System == string.Empty)
            {
                TempData.Add("NotChoosenSystem", "Задължително трябва да въведете Име на услуга!");
                return View(model);
            }
            if (!ModelState.IsValid || model.Role == string.Empty)
            {
                TempData.Add("NotChoosenRole", "Задължително трябва да въведете стойност в поле роля/права/достъп!");
                return View(model);
            }
            var menu = service.SaveMenuItem(model);

            if (!menu)
            {
                TempData.Add("DuplicateRow", "Такъв достъп вече съществува.");
                return View(model);
            }          

            return RedirectToAction("AddInfo", "Menu", model);
        }

        // GET
        public ActionResult AddInfo(AddProfileMenu model)
        {
            return View(model);
        }

        //GET
        public ActionResult Edit(int id)
        {
            AllProfileMenuViewModel menuItem = service.GetMenuItem(id);

            return View(menuItem);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(AllProfileMenuViewModel model)
        {
            if (!ModelState.IsValid || model.System == string.Empty)
            {
                TempData.Add("NotChoosenSystem", "Задължително трябва да въведете Име на услуга!");
                return View(model);
            }
            if (!ModelState.IsValid || model.Role == string.Empty)
            {
                TempData.Add("NotChoosenRole", "Задължително трябва да въведете стойност в поле роля/права/достъп");
                return View(model);
            }
            var menuItem = service.EditMenuItem(model);

            TempData.Add("SuccessEdit", "Успешно променихте записа.");
            return RedirectToAction("Edit", "Menu", new { id = model.Id});
        }
    }
}