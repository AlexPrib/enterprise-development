using RecruitmentAgency.Domain.Context;
using RecruitmentAgency.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAgency.Domain.Repositories;

public class ApplicantRepository(RecruitmentAgencyContext context) : IEntityRepository<Applicant>
{
    public IEnumerable<Applicant> GetAll() => context.Applicants;

    public Applicant? GetById(int id) => context.Applicants.Find(id);

    public Applicant Add(Applicant newApplicant)
    {
        var applicant = context.Applicants.Add(newApplicant).Entity;
        context.SaveChanges();
        return applicant;
    }

    public void Delete(Applicant applicant)
    {
        context.Applicants.Remove(applicant);
        context.SaveChanges();
    }

    public Applicant Update(Applicant updatedApplicant)
    {
        var entry = context.Entry(updatedApplicant);
        entry.State = EntityState.Modified;
        context.SaveChanges();
        return entry.Entity;
    }

}
