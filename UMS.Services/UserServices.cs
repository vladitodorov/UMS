namespace UMS.Services
{
    using AutoMapper;
    using System;
    using UMS.Models.EntityModels;
    using UMS.Models.ViewModels.AdAccount;

    public class UserServices : Service
    {
        public AdAccountSingleViewModel GetAccountDetails(int id)
        { 
             AdAccount account = this.Context.AdAccounts.Find(id);
             if (account == null)
                 {
                     return null;
                 }

             AdAccountSingleViewModel accountView = Mapper.Map<AdAccount, AdAccountSingleViewModel>(account);

             return accountView;
        }
    }
}
