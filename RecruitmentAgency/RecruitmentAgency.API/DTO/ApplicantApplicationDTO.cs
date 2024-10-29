namespace RecruitmentAgency.API.DTO;

/// <summary>
/// DTO заявки соискателя
/// </summary>
public class ApplicantApplicantDTO
{
    /// <summary>
    /// Идентификатор заявки соискателя
    /// </summary>
    public required int Id { get; set; }
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
