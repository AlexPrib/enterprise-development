using AutoMapper;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain.Entity;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.API.Services;

public class EmployerApplicationService(IEntityRepository<EmployerApplication> employerapplicationRepository, IEntityRepository<Employer> employerRepository, IEntityRepository<Position> positionRepository, IMapper mapper) : IEntityService<EmployerApplicationDTO, EmployerApplicationCreateDTO>
{
    public IEnumerable<EmployerApplicationDTO> GetAll() => employerapplicationRepository.GetAll().Select(mapper.Map<EmployerApplicationDTO>);

    public EmployerApplicationDTO? GetById(int id) => mapper.Map<EmployerApplicationDTO>(employerapplicationRepository.GetById(id));

    public EmployerApplicationDTO? Add(EmployerApplicationCreateDTO newEmployerApplication)
    {
        var employer = employerRepository.GetById(newEmployerApplication.EmployerId);
        var position = positionRepository.GetById(newEmployerApplication.PositionId);
        if (employer == null || position == null)
        {
            return null;
        }
        var applicantapplication = new EmployerApplication
        {
            SubmissionDate = newEmployerApplication.SubmissionDate,
            Employer =  employer,
            Position = position,
            Requirements = newEmployerApplication.Requirements,
            OfferedSalary = newEmployerApplication.OfferedSalary
        };
        return mapper.Map<EmployerApplicationDTO>(employerapplicationRepository.Add(applicantapplication));
    }

    public bool Delete(int id)
    {
        var employerapplication = employerapplicationRepository.GetById(id);
        if (employerapplication == null)
        {
            return false;
        }
        employerapplicationRepository.Delete(employerapplication);
        return true;
    }

    public EmployerApplicationDTO? Update(int id, EmployerApplicationCreateDTO updatedEmployerApplication)
    {
        var employerapplication = employerapplicationRepository.GetById(id);
        if (employerapplication == null)
        {
            return null;
        }
        var employer = employerRepository.GetById(updatedEmployerApplication.EmployerId);
        var position = positionRepository.GetById(updatedEmployerApplication.PositionId);
        if (employer == null || position == null)
        {
            return null;
        }
        employerapplication.SubmissionDate = updatedEmployerApplication.SubmissionDate;
        employerapplication.Employer = employer;
        employerapplication.Position = position;
        employerapplication.Requirements = updatedEmployerApplication.Requirements;
        employerapplication.OfferedSalary = updatedEmployerApplication.OfferedSalary;
        return mapper.Map<EmployerApplicationDTO>(employerapplicationRepository.Update(employerapplication));
    }
}
