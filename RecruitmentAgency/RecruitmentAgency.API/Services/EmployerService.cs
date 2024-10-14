using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Services;

public class EmployerService : IEntityService<Employer, EmployerCreateDTO, EmployerDTO>
{
    private readonly List<Employer> _employer = [];

    private int _id = 1;

    public List<Employer> GetAll() => _employer;

    public Employer? GetById(int id) => _employer.FirstOrDefault(o => o.Id == id);

    public bool Add(EmployerCreateDTO newEmployer)
    {
        var employer = new Employer
        {
            Id = _id++,
            CompanyName = newEmployer.CompanyName,
            ContactPersonName = newEmployer.ContactPersonName,
            CompanyNumber = newEmployer.CompanyNumber,
        };
        _employer.Add(employer);
        return true;
    }

    public bool Delete(int id)
    {
        var employer = GetById(id);
        if (employer == null)
        {
            return false;
        }
        _employer.Remove(employer);
        return true;
    }

    public bool Update(EmployerDTO updatedEmployer)
    {
        var employer = GetById(updatedEmployer.Id);
        if (employer == null)
        {
            return false;
        }
        employer.CompanyName = updatedEmployer.CompanyName;
        employer.ContactPersonName = updatedEmployer.ContactPersonName;
        employer.CompanyNumber = updatedEmployer.CompanyNumber;
        return true;
    }
}
