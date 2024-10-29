using AutoMapper;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain.Entity;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.API.Services;

public class ApplicantsService(IEntityRepository<Applicant> repository, IMapper mapper) : IEntityService<ApplicantDTO, ApplicantCreateDTO>
{
    public IEnumerable<ApplicantDTO> GetAll() => repository.GetAll().Select(mapper.Map<ApplicantDTO>);
    public ApplicantDTO? GetById(int id) => mapper.Map<ApplicantDTO>(repository.GetById(id));

    public ApplicantDTO Add(ApplicantCreateDTO newApplicant) => mapper.Map<ApplicantDTO>(repository.Add(mapper.Map<Applicant>(newApplicant)));

    public bool Delete(int id)
    {
        var applicant = repository.GetById(id);
        if (applicant == null)
        {
            return false;
        }
        repository.Delete(applicant);
        return true;
    }

    public ApplicantDTO? Update(int id, ApplicantCreateDTO updatedApplicant)
    {
        var applicant = repository.GetById(id);
        if (applicant == null)
        {
            return null;
        }
        applicant.FullName = updatedApplicant.FullName;
        applicant.ContactInformation = updatedApplicant.ContactInformation;
        applicant.Experience = updatedApplicant.Experience;
        applicant.Education = updatedApplicant.Education;
        applicant.Salaries = updatedApplicant.Salaries;
        return mapper.Map<ApplicantDTO>(repository.Update(applicant));
    }
}
