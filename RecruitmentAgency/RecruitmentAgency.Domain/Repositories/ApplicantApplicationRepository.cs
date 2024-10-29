using RecruitmentAgency.Domain.Context;
using RecruitmentAgency.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAgency.Domain.Repositories;

public class ApplicantApplicationRepository(RecruitmentAgencyContext context) : IEntityRepository<ApplicantApplication>
{
    public IEnumerable<ApplicantApplication> GetAll()
    {
        return context.ApplicantsApplication
            .Include(s => s.Applicant)
            .Include(s => s.Position);
    }

    public ApplicantApplication? GetById(int id)
    {
        return context.ApplicantsApplication
            .Include(s => s.Applicant)
            .Include(s => s.Position)
            .FirstOrDefault(s => s.Id == id);
    }

    public ApplicantApplication Add(ApplicantApplication newApplicantApplication)
    {
        var applicantApplication = context.ApplicantsApplication.Add(newApplicantApplication).Entity;
        context.SaveChanges();
        return applicantApplication;
    }

    public void Delete(ApplicantApplication applicantApplication)
    {
        context.ApplicantsApplication.Remove(applicantApplication);
        context.SaveChanges();
    }

    public ApplicantApplication Update(ApplicantApplication updatedApplicantApplication)
    {
        var entry = context.Entry(updatedApplicantApplication);
        entry.State = EntityState.Modified;
        context.SaveChanges();
        return entry.Entity;
    }
}
