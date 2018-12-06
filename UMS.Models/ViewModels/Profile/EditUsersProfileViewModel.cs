namespace UMS.Models.ViewModels.Profile
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using UMS.Models.EntityModels;

    public class EditUsersProfileViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        public string Heading { get; set; }

        public string Direction { get; set; }

        public string Directorate { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        public string Position { get; set; }

        public virtual ICollection<ProfileMenu> ProfileMenus { get; set; } = new HashSet<ProfileMenu>();

        public virtual IEnumerable<DisplayAllProfileMenus> AllProfileMenus { get; set; } = new HashSet<DisplayAllProfileMenus>();

    }
}
