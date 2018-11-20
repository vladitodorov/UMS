namespace UMS.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using UMS.Models.EntityModels;
    using UMS.Models.ViewModels.Account;

    public class AccountService : Service
    {
        public AllAccountsViewModel GetAllUsers()
        {
            IEnumerable<User> allAccounts = this.Context.Users.OrderBy(u => u.UserName).ToList();

            var result = new AllAccountsViewModel
            {
                Users = allAccounts
            };

            return result;
        }       
    }
}
