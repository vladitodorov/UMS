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
            if (!context.Users.Any(user => user.UserName == "UmsAdmin"))
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
            PopulateAdGroupTable(context);
            //adding ad users
            PopulateAdUserTable(context);
            //adding opus nonlife users
            PopulateOpusNUserTable(context);
            //adding info into profile tables 
            PopulateProfileTableInfo(context);
            //---------------------------------------------------------------------------------------------------->


        }

        private void PopulateProfileTableInfo(UmsDbContext context)
        {
            context.ProfileHeadings.AddOrUpdate(heading => heading.HeadingName, new ProfileHeading[]
            {
                new ProfileHeading()
                {
                    HeadingName = "Операции",
                    Status = true
                },
                new ProfileHeading()
                {
                    HeadingName = "Подписваческа дейност",
                    Status = true
                },
                new ProfileHeading()
                {
                    HeadingName = "Централни функции",
                    Status = true
                }
            });

            context.ProfileDirections.AddOrUpdate(direction => direction.DirectionName, new ProfileDirection[]
                {
                    new ProfileDirection()
                    {
                        DirectionName = "Ликвидация на щети",
                        Status = true
                    },
                    new ProfileDirection()
                    {
                        DirectionName = "Информационни Технологии",
                        Status = true
                    },
                    new ProfileDirection()
                    {
                        DirectionName = "АСД",
                        Status = true
                    },
                    new ProfileDirection()
                    {
                        DirectionName = "Полици",
                        Status = true
                    },
                    new ProfileDirection()
                    {
                        DirectionName = "Актюери",
                    },
                    new ProfileDirection()
                    {
                        DirectionName = "Деловодство",
                        Status = true
                    },
                });

            context.ProfileDirectorates.AddOrUpdate(directorate => directorate.DirectorateName, new ProfileDirectorate[]
                {
                    new ProfileDirectorate()
                    {
                        DirectorateName = "Щети АЗ",
                        Status = true
                    },
                    new ProfileDirectorate()
                    {
                        DirectorateName = "Щети OЗ",
                        Status = true
                    },
                    new ProfileDirectorate()
                    {
                        DirectorateName = "Щети Живот",
                        Status = true
                    },
                    new ProfileDirectorate()
                    {
                        DirectorateName = "Инфраструктура и услуги",
                        Status = true
                    },
                    new ProfileDirectorate()
                    {
                        DirectorateName = "Програмиране и разработка",
                        Status = true
                    },
                });

            context.ProfilePositions.AddOrUpdate(position => position.PositionName, new ProfilePosition[]
                {
                    new ProfilePosition()
                    {
                        PositionName = "Специалист",
                        Status = true
                    },
                    new ProfilePosition()
                    {
                        PositionName = "Главен специалист",
                        Status = true
                    },
                    new ProfilePosition()
                    {
                        PositionName = "Ръководител",
                        Status = true
                    },
                    new ProfilePosition()
                    {
                        PositionName = "Администратор",
                        Status = true
                    },
                    new ProfilePosition()
                    {
                        PositionName = "Програмист",
                        Status = true
                    },
                    new ProfilePosition()
                    {
                        PositionName = "Деловодител",
                        Status = true
                    },
                    new ProfilePosition()
                    {
                        PositionName = "Актюер",
                        Status = true
                    }
                });
        }

        private void PopulateOpusNUserTable(UmsDbContext context)
        {
            context.OpusNonUsers.AddOrUpdate(user => user.OpusUserName, new OpusNonUser[]
            {
                new OpusNonUser()
                {
                    OpusUserName = "DIVANOVA",
                    Agency = "001",
                    FirstName = "Димитринка",
                    LastName = "Иванова",
                    Egn = 8001126583,
                    DateCreated = DateTime.Parse("2017/01/15"),
                    LastModifiedDate = DateTime.Now
                },

                new OpusNonUser()
                {
                    OpusUserName = "DIVANOVA217",
                    Agency = "217",
                    FirstName = "Димитринка",
                    LastName = "Иванова",
                    Egn = 8001126583,
                    DateCreated = DateTime.Parse("2016/06/15"),
                    LastModifiedDate = DateTime.Now
                },

                new OpusNonUser()
                {
                    OpusUserName = "IYORDANOV",
                    Agency = "473",
                    FirstName = "Димитрика",
                    LastName = "Иванова",
                    Egn = 7807126852,
                    DateCreated = DateTime.Parse("2015/12/15"),
                    LastModifiedDate = DateTime.Now
                },
            });
        }

        private void PopulateAdUserTable(UmsDbContext context)
        {
            context.AdAccounts.AddOrUpdate(account => account.Egn, new AdUser[]
            {
                new AdUser()
                {
                    Egn = 8001126583,
                    FirstName = "Dimitrinka",
                    LastName = "Ivanova",
                    HermesId = 2514,
                    SamAccount = "u967235",
                    IsAcive = true,
                    DateCreated = DateTime.Parse("2017/01/15"),
                    LastModifiedDate = DateTime.Now
                },
                new AdUser()
                {
                    Egn = 7807126852,
                    FirstName = "Ivailo",
                    LastName = "Yordanov",
                    HermesId = 3603,
                    SamAccount = "u480005",
                    IsAcive = true,
                    DateCreated = DateTime.Parse("2015/12/15"),
                    LastModifiedDate = DateTime.Now
                },
                new AdUser()
                {
                    Egn = 8506253602,
                    FirstName = "Kalinka",
                    LastName = "Milanova",
                    HermesId = 5421,
                    SamAccount = "u010025",
                    IsAcive = true,
                    DateCreated = DateTime.Parse("2012/11/05"),
                    LastModifiedDate = DateTime.Now
                },
                new AdUser()
                {
                    Egn = 6609156001,
                    FirstName = "Krasimir",
                    LastName = "Petrov",
                    HermesId = 1023,
                    SamAccount = "u217016",
                    IsAcive = true,
                    DateCreated = DateTime.Parse("2009/01/23"),
                    LastModifiedDate = DateTime.Now
                },
                new AdUser()
                {
                    Egn = 6909282500,
                    FirstName = "Alexander",
                    LastName = "Karakachanov",
                    HermesId = 1569,
                    SamAccount = "u217858",
                    IsAcive = true,
                    DateCreated = DateTime.Parse("2014/02/28"),
                    LastModifiedDate = DateTime.Now
                },
                new AdUser()
                {
                    Egn = 9101116565,
                    FirstName = "Ivan",
                    LastName = "Poyordanov",
                    HermesId = 9654,
                    SamAccount = "u969635",
                    IsAcive = false,
                    DateCreated = DateTime.Parse("2011/07/15"),
                    DateClosed = DateTime.Parse("2018/07/25"),
                    LastModifiedDate = DateTime.Now
                },
                new AdUser()
                {
                    Egn = 7506126549,
                    FirstName = "Kremena",
                    LastName = "Vasileva",
                    HermesId = 7756,
                    SamAccount = "u969602",
                    IsAcive = false,
                    DateCreated = DateTime.Parse("2013/01/10"),
                    DateClosed = DateTime.Parse("2017/06/15"),
                    LastModifiedDate = DateTime.Now
                }
            });
        }

        private void PopulateAdGroupTable(UmsDbContext context)
        {
            context.AdGroups.AddOrUpdate(group => group.GroupName, new AdGroup[]
             {
                new AdGroup() {GroupName = "BPM AUTO"},
                new AdGroup() {GroupName = "BPM AUTO Claim Handler"},
                new AdGroup() {GroupName = "BPM AUTO Claim Handler 2"},
                new AdGroup() {GroupName = "BPM NONLIFE HEADQUARTER"},
                new AdGroup() {GroupName = "ctx AUTO OPUS"},
                new AdGroup() {GroupName = "ctx OraIns"},
             });
        }
    }
}
