namespace UMS.Services
{
    using AutoMapper;
    using System.Collections.Generic;
    using UMS.Models.EntityModels;
    using UMS.Models.ViewModels.AdAccount;

    public class HomeService : Service
    {
        public IEnumerable<AdAccountViewModel> GetAllAdAccounts()
        {
            IEnumerable<AdAccount> adAccounts = this.Context.AdAccounts;

            IEnumerable<AdAccountViewModel> adAccountList = Mapper.Map<IEnumerable<AdAccount>, IEnumerable<AdAccountViewModel>>(adAccounts);

            return adAccountList;
        }
    }
}
