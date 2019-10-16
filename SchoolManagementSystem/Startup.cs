using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using NHAMIS;
using NHAMIS.APP.Models;
using NHAMISAPP;
using Owin;
using SchoolManagementSystem.Models;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(SchoolManagementSystem.Startup))]
namespace SchoolManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            NHAMISContext db = new NHAMISContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);                
            }

            var user = new ApplicationUser();
            user.UserName = "smwadwaa";
            user.Email = "smwadwaa@yahoo.com";
            string userPWD = "Admin@123";

            var chkUser = UserManager.Create(user, userPWD);
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "Admin");

                NominatingBodyCategory ncat = new NominatingBodyCategory();
                ncat.Name = "Ministries";
                db.NominatingBodyCategories.Add(ncat);
                db.SaveChanges();

                NominatingBody nbody = new NominatingBody();
                nbody.Name = "ICT Authority";
                nbody.Order = 20;
                nbody.NominatingBodyCategoryId = ncat.Id;
                db.NominatingBodies.Add(nbody);
                db.SaveChanges();

                if (db.PostalCodes.Count() <= 0)
                {
                    ModelService.InsertPostalCodes();
                }

                var userDetails = new UserDetails();
                userDetails.Designation = "Sofwtare Developer";
                userDetails.EmailAddress = "smwadwaa@yahoo.com";
                userDetails.MobileNo = "0724924465";
                userDetails.NominatingBodyId = nbody.Id;
                userDetails.OtherNames = "Shangala Mwadwaa";
                userDetails.OtherNo = "0733274699";
                userDetails.PFNumber = "0099";
                userDetails.PostalAddress = 5457;
                userDetails.PostalCodeId = db.PostalCodes.Where(c => c.Code == 100).FirstOrDefault().Id;
                userDetails.Surname = "Mwadwaa";
                userDetails.Title = "Mr.";
                userDetails.UserId = user.Id;
                userDetails.UserStatus = true;
                db.UserDetails.Add(userDetails);
                db.SaveChanges();
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("ApproverStageOne"))
            {
                var role = new IdentityRole();
                role.Name = "ApproverStageOne";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("ApproverStageTwo"))
            {
                var role = new IdentityRole();
                role.Name = "ApproverStageTwo";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("ApproverStageThree"))
            {
                var role = new IdentityRole();
                role.Name = "ApproverStageThree";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Super Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Super Admin";
                roleManager.Create(role);
            }
        }
    }
}
