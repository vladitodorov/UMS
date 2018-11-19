namespace UMS.Models.ViewModels.Users
{
    using System.Collections.Generic;
    using UMS.Models.EntityModels;

    public class AllUsersByEgnViewModel
    {
        public AdUser AdUser { get; set; }

        public IEnumerable<OpusNonUser> OpusNonUsers { get; set; }
    }
}
