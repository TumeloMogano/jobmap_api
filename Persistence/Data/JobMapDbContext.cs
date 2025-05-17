using JobMap.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMap.API.Persistence.Data
{
    public class JobMapDbContext : DbContext
    {
        public JobMapDbContext(DbContextOptions<JobMapDbContext> options) : base(options)
        {

        }

        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<HiringLikelihood> HiringLikelihood { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ApplicationTags> ApplicationTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //JobApplication and Tag: ApplicationTags table (many to many)
            builder.Entity<ApplicationTags>()
                .HasKey(t => new { t.ApplicationId, t.TagId });

            builder.Entity<ApplicationTags>()
                .HasOne(t => t.Application)
                .WithMany(r => r.ApplicationTags)
                .HasForeignKey(f => f.ApplicationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ApplicationTags>()
                .HasOne(t => t.Tag)
                .WithMany(t => t.ApplicationTags)
                .HasForeignKey(t => t.TagId)
                .OnDelete(DeleteBehavior.NoAction);

            //Seed Lookup table Data
            builder.Entity<Status>()
                .HasData(
                    new Status { Id = 1, Name = "Prospect" },
                    new Status { Id = 2, Name = "Applied" },
                    new Status { Id = 3, Name = "In Interviews" },
                    new Status { Id = 4, Name = "Requires Follow-Up" },
                    new Status { Id = 5, Name = "Negotiating Offer" },
                    new Status { Id = 6, Name = "Hired" },
                    new Status { Id = 7, Name = "Closed" }
                );

            builder.Entity<HiringLikelihood>()
                .HasData(
                    new HiringLikelihood { Id = 1, Description = "0% - Yet to Apply" },
                    new HiringLikelihood { Id = 2, Description = "0% - Declined Offer" },
                    new HiringLikelihood { Id = 3, Description = "0% - Lost Opportunity" },
                    new HiringLikelihood { Id = 4, Description = "5% - Too Early to Tell" },
                    new HiringLikelihood { Id = 5, Description = "10% - Made Contact" },
                    new HiringLikelihood { Id = 6, Description = "10% - Weak Initial Screening" },
                    new HiringLikelihood { Id = 7, Description = "15% - Scheduled Initial Screening" },
                    new HiringLikelihood { Id = 8, Description = "15% - Weak First Round Interview" },
                    new HiringLikelihood { Id = 9, Description = "20% - Strong Initial Screening" },
                    new HiringLikelihood { Id = 10, Description = "25% - Weak Second Round Interview" },
                    new HiringLikelihood { Id = 11, Description = "30% - Scheduled Interviews" },
                    new HiringLikelihood { Id = 12, Description = "40% - Strong First Round Interview" },
                    new HiringLikelihood { Id = 13, Description = "50% - Scheduled Second Round Interview" },
                    new HiringLikelihood { Id = 14, Description = "60% - Strong Second Round Interview" },
                    new HiringLikelihood { Id = 15, Description = "80% - Received Offer" },
                    new HiringLikelihood { Id = 16, Description = "100% - Accepted Offer" }
                );

            builder.Entity<Tag>()
                .HasData(
                    new Tag { Id = 1, Name = "Part-Time" },
                    new Tag { Id = 2, Name = "Full-Time" },
                    new Tag { Id = 3, Name = "Requires Travel" },
                    new Tag { Id = 4, Name = "Internal Connections" },
                    new Tag { Id = 5, Name = "Hybrid" },
                    new Tag { Id = 6, Name = "Remote" },
                    new Tag { Id = 7, Name = "Temporary" },
                    new Tag { Id = 8, Name = "Permanent" },
                    new Tag { Id = 9, Name = "Part-Time" },
                    new Tag { Id = 10, Name = "Hourly Salary" },
                    new Tag { Id = 11, Name = "Good Graduate Support" },
                    new Tag { Id = 12, Name = "No Graduate Support" }
                );

            builder.Entity<JobApplication>()
                .HasData(
                    new JobApplication
                    {
                        Id = new Guid("a2f5e6c3-6d25-4f8e-94a3-cc377a4f6a99"),
                        CompanyName = "MyCompany Corp",
                        Location = "Pretoria, Gauteng",
                        RoleTitle = "Title",
                        StatusId = 1,
                        MainContactName = "Test",
                        MainContactEmail = "Test@gmail.com",
                        MainContactPhone = "012 123 456",
                        HiringLikelihoodId = 1,
                        OpeningDate = null,
                        DateApplied = new DateTime(2024, 4, 27),
                        ClosingDate = null,
                        SalaryExpectationRange = "R10 000 - R20 000",
                        RequiredDocumentation = "CV, ID",
                        IsClosed = false,
                        Notes = "Additional notes",
                        CreatedAt = new DateTime(2024, 4, 27),
                        UpdatedAt = null
                    }
                );


        }
    }
}
