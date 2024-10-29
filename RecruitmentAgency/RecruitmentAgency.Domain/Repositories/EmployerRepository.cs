using RecruitmentAgency.Domain.Context;
using RecruitmentAgency.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentAgency.Domain.Repositories;

public class EmployerRepository(RecruitmentAgencyContext context) : IEntityRepository<Employer>
{
    public IEnumerable<Employer> GetAll() => context.Employers;

    public Employer? GetById(int id) => context.Employers.Find(id);

    public Employer Add(Employer newEmployer)
    {
        var employer = context.Employers.Add(newEmployer).Entity;
        context.SaveChanges();
        return employer;
    }

    public void Delete(Employer employer)
    {
        context.Employers.Remove(employer);
        context.SaveChanges();
    }

    public Employer Update(Employer updatedEmployer)
    {
        var entry = context.Entry(updatedEmployer);
        entry.State = EntityState.Modified;
        context.SaveChanges();
        return entry.Entity;
    }
}
