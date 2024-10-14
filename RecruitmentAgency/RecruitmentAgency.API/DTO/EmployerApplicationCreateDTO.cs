namespace RecruitmentAgency.API.DTO;

/// <summary>
/// DTO для создания заявки работодателя
/// </summary>
public class EmployerApplicationCreateDTO
{
    /// <summary>
    /// Дата подачи
    /// </summary>
    public required DateTime SubmissionDate { get; set; }
    /// <summary>
    /// Работодатель
    /// </summary>
    public required int EmployerId { get; set; }
    /// <summary>
    /// Должность
    /// </summary>
    public required int PositionId { get; set; }
    /// <summary>
    /// Требование 
    /// </summary>
    public required string Requirements { get; set; }
    /// <summary>
    /// Предлагаемый уровень зарплаты
    /// </summary>
    public required int OfferedSalary { get; set; }
}
