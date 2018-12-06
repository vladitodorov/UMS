namespace UMS.Services
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using UMS.Models.EntityModels;
    using UMS.Models.ViewModels.Menu;

    public class MenuService : Service
    {
        public bool SaveMenuItem(AddProfileMenu model)
        {
            if (this.Context.ProfileMenus.Any(
                            m => m.System == model.System && m.Role == model.Role && m.Description == model.Description))
            {
                return false;
            }
   
            var menu = new ProfileMenu
            {
                System = model.System,
                Role = model.Role,
                Description = model.Description                
            };           

            this.Context.ProfileMenus.Add(menu);
            this.Context.SaveChanges();
            return true;
        }

        public AllProfileMenuViewModelPages GetAllProfileMenus(int page)
        {
            var totalMenus = this.Context.ProfileMenus.Count();
            IEnumerable<ProfileMenu> getProfileMenus = this.Context.ProfileMenus.OrderBy(m => m.System).Skip((page-1)*10).Take(10).ToList();

            if (getProfileMenus == null)
            {
                return null;
            }

            IEnumerable<AllProfileMenuViewModel> profileMenus = Mapper.Map<IEnumerable<ProfileMenu>, IEnumerable<AllProfileMenuViewModel>>(getProfileMenus);

            var allProfileMenus = new AllProfileMenuViewModelPages()
            {
                AllProfileMenus = profileMenus,
                TotalMenus = totalMenus,
                CurrentPage = page
            };

            return allProfileMenus;                
        }

        // GET
        public AllProfileMenuViewModel GetMenuItem(int id)
        {
            var menuItem = this.Context.ProfileMenus.Where(m => m.Id == id).FirstOrDefault();

            AllProfileMenuViewModel item = Mapper.Map<ProfileMenu, AllProfileMenuViewModel>(menuItem);

            return item;
        }

        public bool EditMenuItem(AllProfileMenuViewModel model)
        {
            var menu = this.Context.ProfileMenus.Where(m => m.Id == model.Id).FirstOrDefault();

            menu.Role = model.Role;
            menu.Description = model.Description;

            this.Context.SaveChanges();
            return true;
        }
    }
}
