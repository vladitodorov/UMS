namespace UMS.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UMS.Models.EntityModels;

    internal sealed class Configuration : DbMigrationsConfiguration<UmsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "UMS.DB";
        }

        protected override void Seed(UmsDbContext context)
        {
            //Ckecks if such role exists in database and creates if it doen't exist
            if (!context.Roles.Any(role => role.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Manager");
                manager.Create(role);
            }

            //Ckecks if such role exists in database and creates if it doesn't exist
            if (!context.Roles.Any(role => role.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Administrator");
                manager.Create(role);
            }

            //Creates default user and sets role "administator" for initial login
            if (!context.Users.Any())
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var passwordHasher = new PasswordHasher();

                var user = new User
                {
                    UserName = "UmsAdmin",
                    Email = "umsadmin@mail.com",
                    PasswordHash = passwordHasher.HashPassword("P@ssw0rd"),
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Administrator");
            }


            //Seeds data for testing. It MUST be removed in production-------------------------------------------->

            //adding ad groups
            context.AdGroups.AddOrUpdate(group => group.GroupName, new AdGroup[]
            {
                new AdGroup() {GroupName = "BPM AUTO"},
                new AdGroup() {GroupName = "BPM AUTO Claim Handler"},
                new AdGroup() {GroupName = "BPM AUTO Claim Handler 2"},
                new AdGroup() {GroupName = "BPM NONLIFE HEADQUARTER"},
                new AdGroup() {GroupName = "ctx AUTO OPUS"},
                new AdGroup() {GroupName = "ctx OraIns"},
            });

            //adding ad accounts
            context.AdAccounts.AddOrUpdate(account => account.Egn, new AdAccount[]
            {
                new AdAccount()
                {
                    Egn = 8001126583,
                    FirstName = "Dimitrinka",
                    LastName = "Ivanova",
                    HermesId = 2514,
                    SamAccount = "u967235",
                    IsAcive = true
                },
                new AdAccount()
                {
                    Egn = 7807126852,
                    FirstName = "Ivailo",
                    LastName = "Yordanov",
                    HermesId = 3603,
                    SamAccount = "u480005",
                    IsAcive = true
                },
                new AdAccount()
                {
                    Egn = 8506253602,
                    FirstName = "Kalinka",
                    LastName = "Milanova",
                    HermesId = 5421,
                    SamAccount = "u010025",
                    IsAcive = true
                },
                new AdAccount()
                {
                    Egn = 6609156001,
                    FirstName = "Krasimir",
                    LastName = "Petrov",
                    HermesId = 1023,
                    SamAccount = "u217016",
                    IsAcive = true
                },
                new AdAccount()
                {
                    Egn = 6909282500,
                    FirstName = "Alexander",
                    LastName = "Karakachanov",
                    HermesId = 1569,
                    SamAccount = "u217858",
                    IsAcive = true
                },
                new AdAccount()
                {
                    Egn = 9101116565,
                    FirstName = "Ivan",
                    LastName = "Poyordanov",
                    HermesId = 9654,
                    SamAccount = "u969635",
                    IsAcive = false
                },
                new AdAccount()
                {
                    Egn = 7506126549,
                    FirstName = "Kremena",
                    LastName = "Vasileva",
                    HermesId = 7756,
                    SamAccount = "u969602",
                    IsAcive = false
                },
            });
            //---------------------------------------------------------------------------------------------------->
          
        }
    }
}
