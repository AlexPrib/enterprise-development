using AutoMapper;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain.Entity;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.API.Services;

public class ApplicantApplicationService(IEntityRepository<ApplicantApplication> applicantapplicationRepository, IEntityRepository<Applicant> applicantRepository, IEntityRepository<Position> positionRepository, IMapper mapper) : IEntityService<ApplicantApplicantDTO, ApplicantApplicationCreateDTO>
{
    public IEnumerable<ApplicantApplicantDTO> GetAll() => applicantapplicationRepository.GetAll().Select(mapper.Map<ApplicantApplicantDTO>);

    public ApplicantApplicantDTO? GetById(int id) => mapper.Map<ApplicantApplicantDTO>(applicantapplicationRepository.GetById(id));
    public ApplicantApplicantDTO? Add(ApplicantApplicationCreateDTO newApplicantApplication)
    {
        var applicant = applicantRepository.GetById(newApplicantApplication.ApplicantId);
        var position = positionRepository.GetById(newApplicantApplication.PositionId);
        if (applicant == null || position == null)
        {
            return null;
        }
        var applicantapplication = new ApplicantApplication
        {
            SubmissionDate = newApplicantApplication.SubmissionDate,
            Applicant = applicant,
            Position = position,
        };
        return mapper.Map<ApplicantApplicantDTO>(applicantapplicationRepository.Add(applicantapplication));
    }

    public bool Delete(int id)
    {
        var applicantapplication = applicantapplicationRepository.GetById(id);
        if (applicantapplication == null)
        {
            return false;
        }
        applicantapplicationRepository.Delete(applicantapplication);
        return true;
    }

    public ApplicantApplicantDTO? Update(int id, ApplicantApplicationCreateDTO updatedApplicantApplicant)
    {
        var applicantapplication = applicantapplicationRepository.GetById(id);
        if (applicantapplication == null)
        {
            return null;
        }
        var applicant = applicantRepository.GetById(updatedApplicantApplicant.ApplicantId);
        var position = positionRepository.GetById(updatedApplicantApplicant.PositionId);
        if (applicant == null || position == null)
        {
            return null;
        }
        applicantapplication.SubmissionDate = updatedApplicantApplicant.SubmissionDate;
        applicantapplication.Applicant = applicant;
        applicantapplication.Position = position;
        return mapper.Map<ApplicantApplicantDTO>(applicantapplicationRepository.Update(applicantapplication));
    }
}
