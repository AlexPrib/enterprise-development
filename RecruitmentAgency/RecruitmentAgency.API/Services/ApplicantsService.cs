using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Services;

public class ApplicantsService : IEntityService<Applicant, ApplicantCreateDTO>
{
    private readonly List<Applicant> _applicants = [];

    private int _id = 1;

    public List<Applicant> GetAll() => _applicants;

    public Applicant? GetById(int id) => _applicants.FirstOrDefault(o => o.Id == id);

    public bool Add(ApplicantCreateDTO newApplicant)
    {
        var applicant = new Applicant
        {
            Id = _id++,
            FullName = newApplicant.FullName,
            ContactInformation = newApplicant.ContactInformation,
            Experience = newApplicant.Experience,
            Education = newApplicant.Education,
            Salaries = newApplicant.Salaries
        };
        _applicants.Add(applicant);
        return true;
    }

    public bool Delete(int id)
    {
        var applicant = GetById(id);
        if (applicant == null)
        {
            return false;
        }
        _applicants.Remove(applicant);
        return true;
    }

    public bool Update(int id, ApplicantCreateDTO updatedApplicant)
    {
        var applicant = GetById(id);
        if (applicant == null)
        {
            return false;
        }
        applicant.FullName = updatedApplicant.FullName;
        applicant.ContactInformation = updatedApplicant.ContactInformation;
        applicant.Experience = updatedApplicant.Experience;
        applicant.Education = updatedApplicant.Education;
        applicant.Salaries = updatedApplicant.Salaries;
        return true;
    }
}
