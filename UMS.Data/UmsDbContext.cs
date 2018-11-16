namespace UMS.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using UMS.Models.EntityModels;

    public class UmsDbContext : IdentityDbContext<User>
    {

        public UmsDbContext()
            : base("name=UmsDbContext", throwIfV1Schema: false)
        {
        }

        public static UmsDbContext Create()
        {
            return new UmsDbContext();
        }

        public virtual DbSet<AdAccount> AdAccounts { get; set; }
        public virtual DbSet<AdGroup> AdGroups { get; set; }
    }

}