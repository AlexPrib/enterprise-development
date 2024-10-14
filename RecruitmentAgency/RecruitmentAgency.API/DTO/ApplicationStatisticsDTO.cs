namespace RecruitmentAgency.API.DTO;
/// <summary>
/// DTO для счета заявок
/// </summary>
public class ApplicationStatisticsDTO
{
    /// <summary>
    /// Раздел, к которому относится должность.
    /// </summary>
    public required string Section { get; set; }

    /// <summary>
    /// Название должности.
    /// </summary>
    public required string PositionName { get; set; }

    /// <summary>
    /// Количество заявок от работодателей по данной должности.
    /// </summary>
    public required int EmployerApplicationsCount { get; set; }

    /// <summary>
    /// Количество заявок от соискателей по данной должности.
    /// </summary>
    public required int ApplicantApplicationsCount { get; set; }
}
