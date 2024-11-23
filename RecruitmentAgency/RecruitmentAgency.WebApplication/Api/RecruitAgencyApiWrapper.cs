using RecruitmentAgency.API.DTO;

namespace RecruitmentAgency.WebApplication.Api;

public class RecruitAgencyApiWrapper(IConfiguration configuration) : IRecruitAgencyApiWrapper
{
    public readonly RecruitmentAgencyApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task<ApplicantApplicantDTO> CreateApplicantApplication(ApplicantApplicationCreateDTO newApplicantApplication) => await _client.ApplicantApplicationsPOSTAsync(newApplicantApplication);
    public async Task<ApplicantDTO> CreateApplicant(ApplicantCreateDTO newApplicant) => await _client.ApplicantsPOSTAsync(newApplicant);
    public async Task<EmployerApplicationDTO> CreateEmployerApplication(EmployerApplicationCreateDTO newEmployerApplication) => await _client.EmployerApplicationPOSTAsync(newEmployerApplication);
    public async Task<EmployerDTO> CreateEmployer(EmployerCreateDTO newEmployer) => await _client.EmployerPOSTAsync(newEmployer);
    public async Task<PositionDTO> CreatePosition(PositionCreateDTO newPosition) => await _client.PositionPOSTAsync(newPosition);

    public async Task<ApplicantApplicantDTO?> UpdateApplicantApplication(int id, ApplicantApplicationCreateDTO newApplicantApplication) => await _client.ApplicantApplicationsPUTAsync(id, newApplicantApplication);
    public async Task<ApplicantDTO> UpdateApplicant(int id, ApplicantCreateDTO newApplicant) => await _client.ApplicantsPUTAsync(id, newApplicant);
    public async Task<EmployerApplicationDTO> UpdateEmployerApplication(int id, EmployerApplicationCreateDTO newEmployerApplication) => await _client.EmployerApplicationPUTAsync(id, newEmployerApplication);
    public async Task<EmployerDTO> UpdateEmployer(int id, EmployerCreateDTO newEmployer) => await _client.EmployerPUTAsync(id, newEmployer);
    public async Task<PositionDTO> UpdatePosition(int id, PositionCreateDTO newPosition) => await _client.PositionPUTAsync(id, newPosition);


    public async Task DeleteApplicantApplication(int id) => await _client.ApplicantApplicationsDELETEAsync(id);
    public async Task DeleteApplicant(int id) => await _client.ApplicantsDELETEAsync(id);
    public async Task DeleteEmployerApplication(int id) => await _client.EmployerApplicationDELETEAsync(id);
    public async Task DeleteEmployer(int id) => await _client.EmployerDELETEAsync(id);
    public async Task DeletePosition(int id) => await _client.PositionDELETEAsync(id);

    public async Task<IEnumerable<ApplicantApplicantDTO>> GetAllApplicantApplications() => await _client.ApplicantApplicationsAllAsync();
    public async Task<IEnumerable<ApplicantDTO>> GetAllApplicants() => await _client.ApplicantsAllAsync();
    public async Task<IEnumerable<EmployerApplicationDTO>> GetAllEmployerApplications() => await _client.EmployerApplicationAllAsync();
    public async Task<IEnumerable<EmployerDTO>> GetAllEmployers() => await _client.EmployerAllAsync();
    public async Task<IEnumerable<PositionDTO>> GetAllPositions() => await _client.PositionAllAsync();

    public async Task<ApplicantApplicantDTO> GetApplicantApplication(int id) => await _client.ApplicantApplicationsGETAsync(id);
    public async Task<ApplicantDTO> GetApplicant(int id) => await _client.ApplicantsGETAsync(id);
    public async Task<EmployerApplicationDTO> GetEmployerApplication(int id) => await _client.EmployerApplicationGETAsync(id);
    public async Task<EmployerDTO> GetEmployer(int id) => await _client.EmployerGETAsync(id);
    public async Task<PositionDTO> GetPosition(int id) => await _client.PositionGETAsync(id);

    public async Task<IEnumerable<ApplicantDTO>> GetAllApplicantsByPositionOrderedByFullName(string positionName) => await _client.PositionAsync(positionName);
    public async Task<IEnumerable<ApplicantDTO>> GetAllApplicantsBySubmissionDateRange(DateTime startDate, DateTime endDate) => await _client.DateRangeAsync(startDate, endDate);
    public async Task<IEnumerable<ApplicantsForEmployerApplicationDTO>> GetApplicantsForEmployerApplication(int employerApplicationId) => await _client.EmployerApplicationAsync(employerApplicationId);
    public async Task<IEnumerable<ApplicationStatisticsDTO>> GetApplicationCountBySectionAndPositionAll() => await _client.StatisticsAsync();
    public async Task<IEnumerable<TopEmployerDTO>> GetTopEmployersByApplications() => await _client.TopEmployersAsync();
    public async Task<IEnumerable<EmployerDTO>> GetEmployersWithMaxSalaryApplications() => await _client.MaxSalaryAsync();
}
