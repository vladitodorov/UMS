namespace UMS.Models.ViewModels.Menu
{
    using System;
    using System.Collections.Generic;

    public class AllProfileMenuViewModelPages
    {
        public IEnumerable<AllProfileMenuViewModel> AllProfileMenus { get; set; }

        public int TotalMenus { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalMenus / 10);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
