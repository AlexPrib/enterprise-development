using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Services;

public class ApplicantApplicationService(ApplicantsService applicantsService, PositionService positionService) : IEntityService<ApplicantApplication, ApplicantApplicationCreateDTO, ApplicantApplicantDTO>
{
    private readonly List<ApplicantApplication> _applicantapplication = [];

    private int _id = 1;

    public List<ApplicantApplication> GetAll() => _applicantapplication;

    public ApplicantApplication? GetById(int id) => _applicantapplication.FirstOrDefault(o => o.Id == id);

    public bool Add(ApplicantApplicationCreateDTO newApplicantApplication)
    {
        var applicant = applicantsService.GetById(newApplicantApplication.ApplicantId);
        var position = positionService.GetById(newApplicantApplication.PositionId);
        if (applicant == null || position == null)
        {
            return false;
        }
        var applicantapplication = new ApplicantApplication
        {
            Id = _id++,
            SubmissionDate = newApplicantApplication.SubmissionDate,
            Applicant = applicant,
            Position = position
        };
        _applicantapplication.Add(applicantapplication);
        return true;
    }

    public bool Delete(int id)
    {
        var applicantapplication = GetById(id);
        if (applicantapplication == null)
        {
            return false;
        }
        _applicantapplication.Remove(applicantapplication);
        return true;
    }

    public bool Update(ApplicantApplicantDTO updatedApplicantApplicant)
    {
        var applicantapplication = GetById(updatedApplicantApplicant.Id);
        if (applicantapplication == null)
        {
            return false;
        }
        var applicant = applicantsService.GetById(updatedApplicantApplicant.ApplicantId);
        var position = positionService.GetById(updatedApplicantApplicant.PositionId);
        if (applicant == null || position == null)
        {
            return false;
        }
        applicantapplication.SubmissionDate = updatedApplicantApplicant.SubmissionDate;
        applicantapplication.Applicant = applicant;
        applicantapplication.Position = position;
        return true;
    }
}
