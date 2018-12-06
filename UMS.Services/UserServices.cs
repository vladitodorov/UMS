namespace UMS.Services
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UMS.Models.EntityModels;
    using UMS.Models.ViewModels.AdUsers;
    using UMS.Models.ViewModels.Users;
    using Profile = Models.EntityModels.Profile;

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

        public AllUserProfilesByPages GetAllProfiles(int page)
        {
            var totalProfiles = this.Context.Profiles.Count();

            IEnumerable<Profile> allProfiles = this.Context.Profiles
                .OrderBy(p => p.Heading)
                .OrderBy(p => p.Direction)
                .OrderBy(p => p.Directorate)
                .OrderBy(p => p.Position)
                .Skip((page - 1) * 10)
                .Take(10)                
                .ToList();

            IEnumerable<UsersProfiles> ap = Mapper.Map<IEnumerable<Profile>, IEnumerable<UsersProfiles>>(allProfiles);

            var result = new AllUserProfilesByPages
            {
                UsersProfiles = ap,
                ProfilesCount = totalProfiles,
                CurrentPage = page
            };

            return result;
        }
    }
}
