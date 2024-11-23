
namespace RecruitmentAgency.WASM.Api;

public interface IRecruitAgencyApiWrapper
{
    Task<ApplicantDTO> CreateApplicant(ApplicantCreateDTO newApplicant);
    Task<ApplicantApplicantDTO> CreateApplicantApplication(ApplicantApplicationCreateDTO newApplicantApplication);
    Task<EmployerDTO> CreateEmployer(EmployerCreateDTO newEmployer);
    Task<EmployerApplicationDTO> CreateEmployerApplication(EmployerApplicationCreateDTO newEmployerApplication);
    Task<PositionDTO> CreatePosition(PositionCreateDTO newPosition);
    Task DeleteApplicant(int id);
    Task DeleteApplicantApplication(int id);
    Task DeleteEmployer(int id);
    Task DeleteEmployerApplication(int id);
    Task DeletePosition(int id);
    Task<IEnumerable<ApplicantApplicantDTO>> GetAllApplicantApplications();
    Task<IEnumerable<ApplicantDTO>> GetAllApplicants();
    Task<IEnumerable<ApplicantDTO>> GetAllApplicantsByPositionOrderedByFullName(string positionName);
    Task<IEnumerable<ApplicantDTO>> GetAllApplicantsBySubmissionDateRange(DateTime startDate, DateTime endDate);
    Task<IEnumerable<EmployerApplicationDTO>> GetAllEmployerApplications();
    Task<IEnumerable<EmployerDTO>> GetAllEmployers();
    Task<IEnumerable<PositionDTO>> GetAllPositions();
    Task<ApplicantDTO> GetApplicant(int id);
    Task<ApplicantApplicantDTO> GetApplicantApplication(int id);
    Task<IEnumerable<ApplicantsForEmployerApplicationDTO>> GetApplicantsForEmployerApplication(int employerApplicationId);
    Task<IEnumerable<ApplicationStatisticsDTO>> GetApplicationCountBySectionAndPositionAll();
    Task<EmployerDTO> GetEmployer(int id);
    Task<EmployerApplicationDTO> GetEmployerApplication(int id);
    Task<PositionDTO> GetPosition(int id);
    Task<IEnumerable<TopEmployerDTO>> GetTopEmployersByApplications();
    Task<ApplicantDTO> UpdateApplicant(int id, ApplicantCreateDTO newApplicant);
    Task<ApplicantApplicantDTO?> UpdateApplicantApplication(int id, ApplicantApplicationCreateDTO newApplicantApplication);
    Task<EmployerDTO> UpdateEmployer(int id, EmployerCreateDTO newEmployer);
    Task<EmployerApplicationDTO> UpdateEmployerApplication(int id, EmployerApplicationCreateDTO newEmployerApplication);
    Task<PositionDTO> UpdatePosition(int id, PositionCreateDTO newPosition);
    Task<IEnumerable<EmployerDTO>> GetEmployersWithMaxSalaryApplications();
}