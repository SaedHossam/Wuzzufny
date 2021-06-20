using DAL.Models;
using DAL.Models.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public string CurrentUserId { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobDetails> JobsDetails { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CompanyManager> CompanyManagers { get; set; }
        public DbSet<CareerLevel> CareerLevels { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CompanyIndustry> CompanyIndustries { get; set; }
        public DbSet<CompanyLinks> CompanyLinks { get; set; }
        public DbSet<CompanySize> CompanySizes { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<EmployeeLinks> EmployeeLinks { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<SalaryRate> SalaryRates { get; set; }
        //public DbSet<SocialLinks> SocialLinks { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<CompanyRequestStatus> CompanyRequestStatus { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }


        public DbSet<JobSkill> JobSkill { get; set; }



        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>()
                .HasOne(e => e.Nationality)
                .WithMany(c => c.EmployeesNationality)
                .HasForeignKey(e => e.NationalityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Employee>()
                .HasOne(e => e.Country)
                .WithMany(c => c.EmployeesLocation)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<JobSkill>().HasKey(js => new { js.JobsId, js.SkillsId });

            builder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Job>().Property(j => j.TotalClicks).HasDefaultValue(0);
            builder.Entity<Job>().Property(j => j.TotalApplications).HasDefaultValue(0);
            builder.Entity<Job>().Property(j => j.AcceptedApplications).HasDefaultValue(0);
            builder.Entity<Job>().Property(j => j.InConsidrationApplications).HasDefaultValue(0); 
            builder.Entity<Job>().Property(j => j.RejectedApplications).HasDefaultValue(0);
            builder.Entity<Job>().Property(j => j.ViewedApplications).HasDefaultValue(0); 
            builder.Entity<Job>().Property(j => j.WithdrawnApplications).HasDefaultValue(0);

            // TODO: Test this shit
            //builder.Entity<Application>().Property(j => j.ApplicationStatusId).HasDefaultValue(ApplicationStatuses.First(a => a.Name == Enums.ApplicationStatus.Applied.ToString()).Id);
            


            //builder.Entity<ApplicationUser>().HasOne<Employee>(au => au.Employee).WithOne(e => e.User)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<ApplicationUser>().HasOne<CompanyManager>(au => au.CompanyManager).WithOne(cm => cm.User)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Employee>().HasOne<ApplicationUser>(e => e.User).WithOne(au => au.Employee)
            //    .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<CompanyManager>().HasOne<ApplicationUser>(cm => cm.User).WithOne(au => au.CompanyManager)
            //    .OnDelete(DeleteBehavior.NoAction);


        }




        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                DateTime now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }
    }
}
