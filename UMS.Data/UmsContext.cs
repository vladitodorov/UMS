namespace UMS.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using UMS.Models.EntityModels;

    public class UmsContext : IdentityDbContext<User>
    {

        public UmsContext()
            : base("name=UmsContext", throwIfV1Schema: false)
        {
        }

        public static UmsContext Create()
        {
            return new UmsContext();
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

}