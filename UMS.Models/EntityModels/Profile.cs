namespace UMS.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Profile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        public string Heading { get; set; }

        public string Direction { get; set; }

        public string Directorate { get; set; }

        [Required(ErrorMessage = "Задължително поле")]
        public string Position { get; set; }

        public virtual ICollection<ProfileMenu> ProfileMenus { get; set; } = new HashSet<ProfileMenu>();
    }
}
