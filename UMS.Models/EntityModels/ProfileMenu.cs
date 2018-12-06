namespace UMS.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProfileMenu
    {
        public int Id { get; set; }

        [Required]
        public string System { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
    }
}
