using Microsoft.EntityFrameworkCore;
using RecruitmentAgency.Domain.Context;
using RecruitmentAgency.Domain.Entity;

namespace RecruitmentAgency.Domain.Repositories;

public class EmployerApplicationRepository(RecruitmentAgencyContext context) : IEntityRepository<EmployerApplication>
{
    public IEnumerable<EmployerApplication> GetAll()
    {
        return context.EmployersApplication
            .Include(s => s.Employer)
            .Include(s => s.Position);
    }

    public EmployerApplication? GetById(int id)
    {
        return context.EmployersApplication
            .Include(s => s.Employer)
            .Include(s => s.Position)
            .FirstOrDefault(s => s.Id == id);
    }

    public EmployerApplication Add(EmployerApplication newEmployerApplication)
    {
        var employerApplication = context.EmployersApplication.Add(newEmployerApplication).Entity;
        context.SaveChanges();
        return employerApplication;
    }

    public void Delete(EmployerApplication employerApplication)
    {
        context.EmployersApplication.Remove(employerApplication);
        context.SaveChanges();
    }

    public EmployerApplication Update(EmployerApplication updatedEmployerApplication)
    {
        var entry = context.Entry(updatedEmployerApplication);
        entry.State = EntityState.Modified;
        context.SaveChanges();
        return entry.Entity;
    }
}
