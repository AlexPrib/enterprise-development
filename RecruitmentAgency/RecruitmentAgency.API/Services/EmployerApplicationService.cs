using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Services;

public class EmployerApplicationService(EmployerService employerService, PositionService positionService) : IEntityService<EmployerApplication, EmployerApplicationCreateDTO, EmployerApplicationDTO>
{
    private readonly List<EmployerApplication> _employerapplication = [];

    private int _id = 1;

    public List<EmployerApplication> GetAll() => _employerapplication;

    public EmployerApplication? GetById(int id) => _employerapplication.FirstOrDefault(o => o.Id == id);

    public bool Add(EmployerApplicationCreateDTO newEmployerApplication)
    {
        var employer = employerService.GetById(newEmployerApplication.EmployerId);
        var position = positionService.GetById(newEmployerApplication.PositionId);
        if (employer == null || position == null)
        {
            return false;
        }
        var employerapplication = new EmployerApplication
        {
            Id = _id++,
            SubmissionDate = newEmployerApplication.SubmissionDate,
            Employer = employer,
            Position = position,
            Requirements = newEmployerApplication.Requirements,
            OfferedSalary = newEmployerApplication.OfferedSalary
        };
        _employerapplication.Add(employerapplication);
        return true;
    }

    public bool Delete(int id)
    {
        var employerapplication = GetById(id);
        if (employerapplication == null)
        {
            return false;
        }
        _employerapplication.Remove(employerapplication);
        return true;
    }

    public bool Update(EmployerApplicationDTO updatedEmployerApplicant)
    {
        var employerapplication = GetById(updatedEmployerApplicant.Id);
        if (employerapplication == null)
        {
            return false;
        }
        var employer = employerService.GetById(updatedEmployerApplicant.EmployerId);
        var position = positionService.GetById(updatedEmployerApplicant.PositionId);
        if (employer == null || position == null)
        {
            return false;
        }
        employerapplication.SubmissionDate = updatedEmployerApplicant.SubmissionDate;
        employerapplication.Employer = employer;
        employerapplication.Position = position;
        employerapplication.Requirements = updatedEmployerApplicant.Requirements;
        employerapplication.OfferedSalary = updatedEmployerApplicant.OfferedSalary;
        return true;
    }
}
