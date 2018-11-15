namespace UMS.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using UMS.Models.EntityModels;

    public class UmsDbContext : IdentityDbContext<User>
    {
        public UmsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static UmsDbContext Create()
        {
            return new UmsDbContext();
        }
    }
}
