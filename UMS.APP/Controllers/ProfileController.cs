namespace UMS.APP.Controllers
{
    using System.Web.Mvc;
    using UMS.Models.ViewModels.Profile;
    using UMS.Services;

    public class ProfileController : BaseController
    {
        private ProfileServices services;

        public ProfileController()
        {
            this.services = new ProfileServices();
        }

        // GET: Add new profile
        public ActionResult Add()
        {
            var model = new AddNewProfileViewModel();

            model.Headings = services.GetAllHeadings();
            model.Directions = services.GetAllDirections();
            model.Directorates = services.GetAllDirectorates();
            model.Positions = services.GetAllPositions();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddNewProfileViewModel model)
        {
            model.Headings = services.GetAllHeadings();
            model.Directions = services.GetAllDirections();
            model.Directorates = services.GetAllDirectorates();
            model.Positions = services.GetAllPositions();

            if (!ModelState.IsValid || model.SelectedHeading.Contains("--- Изберете стойност ---") || model.SelectedPosition.Contains("--- Изберете стойност ---"))
            {
                TempData.Add("NotSelectedItem", "Задължително е избирането на стойност за Направление и Позиция!");
                return View(model);
            }

            var savedData = services.SaveData(model);

            if (!savedData)
            {
                TempData.Add("DuplicateProfile", "Такъв профил вече съществува!");
                return View(model);
            }

           return RedirectToAction("AddInfo", "Profile", model);
        }

        public ActionResult AddInfo(AddNewProfileViewModel model)
        {
            return View(model);
        }

        [HandleError]
        public ActionResult Edit(int id)
        {
            EditUsersProfileViewModel editUsersProfile = this.services.GetUsersProfileById(id);

            return View(editUsersProfile);
        }

        public ActionResult EditMenu(int id, string system, string role, int profileId, string heading, string direction, string directorate, string position)
        {
            var result = new EditMenuViewModel
            {
                Id = profileId,
                Heading = heading,
                Direction = direction,
                Directorate = directorate,
                Position = position,
                ProfileMenuId = id,
                ProfileMenuSystem = system,
                ProfileMenuRole = role
            };

            return View(result);
        }

        [HttpPost]
        public ActionResult EditMenu(int id, int profileId)
        {
            var result = services.UpdateProfileMenu(id, profileId);

            if (!result)
            {
                return HttpNotFound();
            }

            id = profileId;

            TempData.Add("SuccessAddProfileMenu", "Успешно добавихте услуга към профила.");
            return RedirectToAction("Edit", "Profile", new { id });
        }
    }
}