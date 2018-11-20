namespace UMS.Models.ViewModels.Account
{
    using System.Collections.Generic;
    using UMS.Models.EntityModels;

    public class AllAccountsViewModel
    {
        public IEnumerable<User> Users { get; set; } = new HashSet<User>();
    }
}
