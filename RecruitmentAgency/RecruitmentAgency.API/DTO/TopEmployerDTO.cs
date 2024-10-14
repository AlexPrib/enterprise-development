namespace RecruitmentAgency.API.DTO;
/// <summary>
/// DTO для топ работодателей
/// </summary>
public class TopEmployerDTO
{
    /// <summary>
    /// Идентификатор работодателя.
    /// </summary>
    public required int EmployerId { get; set; }

    /// <summary>
    /// Название работодателя.
    /// </summary>
    public required string EmployerName { get; set; }

    /// <summary>
    /// Количество заявок от данного работодателя.
    /// </summary>
    public required int ApplicationsCount { get; set; }
}
