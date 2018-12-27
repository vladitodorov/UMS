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

        public virtual DbSet<AdUser> AdAccounts { get; set; }
        public virtual DbSet<AdGroup> AdGroups { get; set; }
        public virtual DbSet<OpusNonUser> OpusNonUsers { get; set; }
        public virtual DbSet<ProfileHeading> ProfileHeadings { get; set; }
        public virtual DbSet<ProfileDirection> ProfileDirections { get; set; }
        public virtual DbSet<ProfileDirectorate> ProfileDirectorates { get; set; }
        public virtual DbSet<ProfilePosition> ProfilePositions { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileMenu> ProfileMenus { get; set; }
        public virtual DbSet<SysAidRequest> SysAidRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Profile>()
                .HasMany<ProfileMenu>(p => p.ProfileMenus)
                .WithMany(pm => pm.Profiles)
                .Map(r =>
                {
                    r.MapLeftKey("Profile_Id");
                    r.MapRightKey("ProfileMenu_Id");
                    r.ToTable("ProfileProfileMenus");
                });

            base.OnModelCreating(builder);
        }
    }

}