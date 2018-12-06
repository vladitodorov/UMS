namespace UMS.Models.ViewModels.Menu
{
    using System.Collections.Generic;
    using UMS.Models.EntityModels;

    public class AllProfileMenuViewModel
    {
        public int Id { get; set; }

        public string System { get; set; }

        public string Role { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; } = new HashSet<Profile>();
    }
}
