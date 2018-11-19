namespace UMS.Services
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using UMS.Models.EntityModels;
    using UMS.Models.ViewModels.AdUsers;
    using UMS.Models.ViewModels.Users;

    public class UserServices : Service
    {
        public AdUserByEgnViewModel GetUserByEgn(long egn)
        {
            AdUser user = this.Context.AdAccounts.Where(u => u.Egn == egn).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            AdUserByEgnViewModel uv = Mapper.Map<AdUser, AdUserByEgnViewModel>(user);

            return uv;
        }

        public AllUserDetailsByEgn GetAllUserDetailsByEgn(long egnLong)
        {
            AdUser adUser = this.Context.AdAccounts.Where(u => u.Egn == egnLong).FirstOrDefault();
            IEnumerable<OpusNonUser> opusNonUsers = this.Context.OpusNonUsers.Where(u => u.Egn == egnLong).ToList();

            var result = new AllUserDetailsByEgn
            {
                Egn = egnLong,
                AdUser = adUser,
                OpusNonUsers = opusNonUsers
            };

            return result;
        }
    }
}
