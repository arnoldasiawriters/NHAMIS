using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NHAMIS.APP.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace NHAMIS
{
    public class NHAMISContext : IdentityDbContext
    {
        public NHAMISContext() : base("SMSWEBConnection")
        {
            Database.SetInitializer<NHAMISContext>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static NHAMISContext Create()
        {
            return new NHAMISContext();
        }

        //Identity and Authorization
        public DbSet<IdentityUserLogin> UserLogins { get; set; }
        public DbSet<IdentityUserClaim> UserClaims { get; set; }
        public DbSet<IdentityUserRole> UserRoles { get; set; }

        public DbSet<AcademicQualification> AcademicQualifications { get; set; }
        public DbSet<ApprovalStages> ApprovalStages { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<HonorRole> HonorRoles { get; set; }
        public DbSet<Medal> Medals { get; set; }
        public DbSet<MedalTransactions> MedalTransactions { get; set; }
        public DbSet<NominatingBody> NominatingBodies { get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<NominationApprovals> NominationApprovals { get; set; }
        public DbSet<NominationAttachment> NominationAttachments { get; set; }
        public DbSet<NominationPeriod> NominationPeriods { get; set; }
        public DbSet<Salutation> Salutations { get; set; }
        public DbSet<SubCounty> SubCounties { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<NomineeRecords> NomineeRecords { get; set; }
        public DbSet<RecordType> RecordTypes { get; set; }
        public DbSet<AttachmentType> AttachmentTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Configure Asp Net Identity Tables
            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<IdentityUser>().Property(u => u.PasswordHash).HasMaxLength(500);
            modelBuilder.Entity<IdentityUser>().Property(u => u.SecurityStamp).HasMaxLength(500);
            modelBuilder.Entity<IdentityUser>().Property(u => u.PhoneNumber).HasMaxLength(50);

            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            modelBuilder.Entity<IdentityUserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);
            /**
            modelBuider.Entity<StaffDetails>()
                .HasRequired(cw => cw.CountyWard)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuider.Entity<StudentDetails>()
                .HasRequired(cw => cw.CountyWard)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuider.Entity<Parent>()
                .HasRequired(cw => cw.CountyWard)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuider.Entity<SchoolDetails>()
                .HasRequired(cw => cw.CoutyWard)
                .WithMany()
                .WillCascadeOnDelete(false); **/
            base.OnModelCreating(modelBuilder);
        }
        /**
        public override int SaveChanges()
        {
            try
            {
                AddTimestamps();
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ve)
            {
                var errors = new List<string>();
                foreach (var e in ve.EntityValidationErrors)
                {
                    errors.AddRange(e.ValidationErrors.Select(e2 => string.Join("Validation Error :: ", e2.PropertyName, " : ", e2.ErrorMessage)));
                }
                var error = string.Join("\r\n", errors);
                var betterException = new Exception(error, ve);

                throw betterException;
            }

        }
        **/
        public override int SaveChanges()
        {
            try
            {
                AddTimestamps();
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join(" ",errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, "The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is NHAMISBaseClass && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUserId = !string.IsNullOrEmpty(HttpContext.Current?.User?.Identity?.GetUserId())
            ? HttpContext.Current.User.Identity.GetUserId()
            : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((NHAMISBaseClass)entity.Entity).CreateDate = DateTime.Now;
                    ((NHAMISBaseClass)entity.Entity).CreateBy = currentUserId;
                }

               entity.Property("CreateBy").IsModified = false;
               entity.Property("CreateDate").IsModified = false;

                ((NHAMISBaseClass)entity.Entity).ModifyDate = DateTime.Now;
                ((NHAMISBaseClass)entity.Entity).ModifyBy = currentUserId;
            }
        }

        public void JulieLermanUpdateTimeStamps()
        {
            foreach (var auditTrail in ChangeTracker.Entries().Where(e => e.Entity is NHAMISBaseClass && (e.State == EntityState.Added ||
            e.State == EntityState.Modified)).Select(e => e.Entity as NHAMISBaseClass))
            {
                auditTrail.ModifyDate = DateTime.Now;
                auditTrail.ModifyBy = HttpContext.Current.User.Identity.GetUserId();
                if (auditTrail.CreateDate == DateTime.MinValue)
                {
                    auditTrail.CreateDate = DateTime.Now;
                    auditTrail.CreateBy = HttpContext.Current.User.Identity.GetUserId();
                }
            }
            /**
                int result = base.SaveChanges();
                foreach (var history in this.ChangeTracker.Entries().Where(e => e.Entity is IModificationHistory).Select(e => e.Entity as IModificationHistory))
                {
                    history.IsDirty = false;
                }
            **/
        }
    }
}
