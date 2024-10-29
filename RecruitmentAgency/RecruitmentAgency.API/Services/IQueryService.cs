using RecruitmentAgency.API.DTO;

namespace RecruitmentAgency.API.Services;
/// <summary>
/// Интерфейс для запросов
/// </summary>
public interface IQueryService
{
    /// <summary>
    /// Вывести сведения о всех соискателях, ищущих работу по заданной должности, упорядочить по ФИО.
    /// </summary>
    public List<ApplicantDTO> GetAllApplicantsByPositionOrderedByFullName(string positionName);
    /// <summary>
    /// Вывести всех соискателей, оставивших заявки за заданный период.
    /// </summary>
    public List<ApplicantDTO> GetAllApplicantsBySubmissionDateRange(DateTime startDate, DateTime endDate);
    /// <summary>
    /// Вывести сведения о соискателях, соответствующих определенной заявке работодателя.
    /// </summary>
    public List<ApplicantsForEmployerApplicationDTO> GetApplicantsForEmployerApplication(int employerApplicationId);
    /// <summary>
    /// Вывести информацию о количестве заявок по каждому разделу и должности.
    /// </summary>
    public List<ApplicationStatisticsDTO> GetApplicationCountBySectionAndPositionAll();
    /// <summary>
    /// Вывести топ 5 работодателей по количеству заявок.
    /// </summary>
    public List<TopEmployerDTO> GetTopEmployersByApplications();
    /// <summary>
    /// Вывести информацию о работодателях, открывших заявки с максимальным уровнем зарплаты.
    /// </summary>
    public List<EmployerDTO> GetEmployersWithMaxSalaryApplications();
}
