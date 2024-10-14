namespace RecruitmentAgency.API.DTO;

/// <summary>
/// DTO для создания заявки соискателя
/// </summary>
public class ApplicantApplicationCreateDTO
{
    /// <summary>
    /// Дата подачи
    /// </summary>
    public required DateTime SubmissionDate { get; set; }
    /// <summary>
    /// Соискатель 
    /// </summary>
    public required int ApplicantId { get; set; }
    /// <summary>
    /// Должность 
    /// </summary>
    public required int PositionId { get; set; }
}
