namespace UMS.Services
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using UMS.Models.EntityModels;
    using UMS.Models.ViewModels.Profile;

    public class ProfileServices : Service
    {
        public IEnumerable<SelectListItem> GetAllHeadings()
        {
            var selectList = new List<SelectListItem>();

            var headings = this.Context.ProfileHeadings
                .Where(h => h.Status == true)
                .OrderBy(h => h.HeadingName)
                .Select(h => h.HeadingName)
                .ToList();

            foreach (var element in headings)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return new SelectList(selectList, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetAllPositions()
        {
            var selectList = new List<SelectListItem>();

            var positions = this.Context.ProfilePositions
                .Where(p => p.Status == true)
                .OrderBy(p => p.PositionName)
                .Select(p => p.PositionName)
                .ToList();

            foreach (var element in positions)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return new SelectList(selectList, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetAllDirectorates()
        {
            var selectList = new List<SelectListItem>();

            var directorates = this.Context.ProfileDirectorates
                .Where(d => d.Status == true)
                .OrderBy(d => d.DirectorateName)
                .Select(d => d.DirectorateName)
                .ToList();

            foreach (var element in directorates)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return new SelectList(selectList, "Value", "Text");
        }

        public EditUsersProfileViewModel GetUsersProfileById(int id)
        {
            UMS.Models.EntityModels.Profile userProfile = this.Context.Profiles
                .Where(p => p.Id == id)
                .FirstOrDefault();

            IEnumerable<ProfileMenu> profileMenus = this.Context.ProfileMenus
                .OrderBy(pm => pm.System)
                .ThenBy(pm => pm.Role)
                .ToList();

            IEnumerable<DisplayAllProfileMenus> displayProfileMenus = Mapper.Map<IEnumerable<ProfileMenu>, IEnumerable<DisplayAllProfileMenus>>(profileMenus);

            EditUsersProfileViewModel editUsersProfileView = new EditUsersProfileViewModel
            {
                Id = userProfile.Id,
                Heading = userProfile.Heading,
                Direction = userProfile.Direction,
                Directorate = userProfile.Directorate,
                Position = userProfile.Position,
                ProfileMenus = userProfile.ProfileMenus,
                AllProfileMenus = displayProfileMenus
            };

            return editUsersProfileView;
        }

        public bool UpdateProfileMenu(int id, int profileId)
        {
            var result = this.Context.Profiles
                .Where(p => p.Id == profileId)
                .FirstOrDefault();
            var menu = this.Context.ProfileMenus
                .Where(pm => pm.Id == id)
                .FirstOrDefault();

            result.ProfileMenus.Add(menu);
            this.Context.SaveChanges();

            return true;
        }

        public IEnumerable<SelectListItem> GetAllDirections()
        {
            var selectList = new List<SelectListItem>();

            var directions = this.Context.ProfileDirections
                .Where(d => d.Status == true)
                .OrderBy(d => d.DirectionName)
                .Select(d => d.DirectionName)
                .ToList();

            foreach (var element in directions)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return new SelectList(selectList, "Value", "Text");
        }

        public bool SaveData(AddNewProfileViewModel model)
        {
            var direction = model.SelectedDirection;

            if (direction == "--- Изберете стойност ---")
            {
                direction = string.Empty;
            }

            var directorate = model.SelectedDirectorate;

            if (directorate == "--- Изберете стойност ---")
            {
                directorate = string.Empty;
            }

            var profile = new UMS.Models.EntityModels.Profile
            {
                Heading = model.SelectedHeading,
                Direction = direction,
                Directorate = directorate,
                Position = model.SelectedPosition
            };

            if (this.Context.Profiles.Any(p => p.Heading == model.SelectedHeading
                                    && p.Direction == direction
                                    && p.Directorate == directorate
                                    && p.Position == model.SelectedPosition))
            {
                return false;
            }
            else
            {
                this.Context.Profiles.Add(profile);
                this.Context.SaveChanges();
                return true;
            }

        }
    }
}
