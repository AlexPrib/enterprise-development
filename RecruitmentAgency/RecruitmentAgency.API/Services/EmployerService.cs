using AutoMapper;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain.Entity;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.API.Services;

public class EmployerService(IEntityRepository<Employer> repository, IMapper mapper) : IEntityService<EmployerDTO, EmployerCreateDTO>
{
    public IEnumerable<EmployerDTO> GetAll() => repository.GetAll().Select(mapper.Map<EmployerDTO>);
    public EmployerDTO? GetById(int id) => mapper.Map<EmployerDTO>(repository.GetById(id));
    public EmployerDTO Add(EmployerCreateDTO newEmployer) => mapper.Map<EmployerDTO>(repository.Add(mapper.Map<Employer>(newEmployer)));
    public bool Delete(int id)
    {
        var employer = repository.GetById(id);
        if (employer == null)
        {
            return false;
        }
        repository.Delete(employer);
        return true;
    }

    public EmployerDTO? Update(int id, EmployerCreateDTO updatedEmployer)
    {
        var employer = repository.GetById(id);
        if (employer == null)
        {
            return null;
        }
        employer.CompanyName = updatedEmployer.CompanyName;
        employer.ContactPersonName = updatedEmployer.ContactPersonName;
        employer.CompanyNumber = updatedEmployer.CompanyNumber;
        return mapper.Map<EmployerDTO>(repository.Update(employer));
    }
}
