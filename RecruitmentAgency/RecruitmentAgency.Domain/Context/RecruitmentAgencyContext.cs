using Microsoft.EntityFrameworkCore;
using RecruitmentAgency.Domain.Entity;

namespace RecruitmentAgency.Domain.Context;

public class RecruitmentAgencyContext(DbContextOptions<RecruitmentAgencyContext> options) : DbContext(options)
{
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<ApplicantApplication> ApplicantsApplication { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<EmployerApplication> EmployersApplication { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicantApplication>(entity =>
        {
            entity.HasOne(c => c.Applicant)
                .WithMany()
                .HasForeignKey("applicant_id")
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(c => c.Position)
                .WithMany()
                .HasForeignKey("position_id")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<EmployerApplication>(entity =>
        {
            entity.HasOne(s => s.Employer)
                .WithMany()
                .HasForeignKey("employer_id")
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(s => s.Position)
                .WithMany()
                .HasForeignKey("position_id")
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
