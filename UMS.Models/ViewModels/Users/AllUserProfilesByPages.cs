namespace UMS.Models.ViewModels.Users
{
    using System;
    using System.Collections.Generic;

    public class AllUserProfilesByPages
    {
        public IEnumerable<UsersProfiles> UsersProfiles { get; set; }

        public int ProfilesCount { get; set; }

        public int TotalPages => (int)Math.Ceiling(((double)this.ProfilesCount / 10));

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == TotalPages ? this.TotalPages : CurrentPage + 1;
    }   
}
