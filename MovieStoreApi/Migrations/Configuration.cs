namespace MovieStoreApi.Migrations
{
    using MovieStoreApi.Models;
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MovieStoreApi.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            CreateRoles(context);
            CreateSuperAdmin(context);
        }

        private void CreateRoles(ApplicationDbContext context)
        {
            var rolestore = new RoleStore<IdentityRole>(context);
            var rolemanager = new RoleManager<IdentityRole>(rolestore);

            if(!context.Roles.Any(r => r.Name == "admin"))
            {
                var role = new IdentityRole { Name = "admin"  };
                rolemanager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "superAdmin"))
            {
                var role = new IdentityRole { Name = "superAdmin" };
                rolemanager.Create(role);
            }
        }

        private void CreateSuperAdmin(ApplicationDbContext context)
        {
            var userstore = new UserStore<ApplicationUser>(context);
            var usermanager = new UserManager<ApplicationUser>(userstore);


            if (!context.Users.Any(u => u.UserName == "siggi"))
            {
                var user = new ApplicationUser { Email = "siggi@thordar.is", UserName = "siggith" };
                usermanager.Create(user, "Password1!");
                usermanager.AddToRole(user.Id, "superAdmin");
            }
        }    
    }
}
