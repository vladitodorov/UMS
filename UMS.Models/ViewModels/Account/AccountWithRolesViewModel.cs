namespace UMS.Models.ViewModels.Account
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AccountWithRolesViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<string> Roles { get; set; } = new HashSet<string>();
    }
}
