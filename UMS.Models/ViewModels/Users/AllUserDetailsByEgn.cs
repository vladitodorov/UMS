namespace UMS.Models.ViewModels.Users
{
    using System.Collections.Generic;
    using UMS.Models.EntityModels;

    public class AllUserDetailsByEgn
    {
        public long Egn { get; set; }

        public  AdUser AdUser { get; set; }

        public IEnumerable<OpusNonUser> OpusNonUsers { get; set; }
    }
}
