namespace RecruitmentAgency.API.DTO;

/// <summary>
/// DTO должности
/// </summary>
public class PositionDTO
{
    /// <summary>
    /// Идентификатор должности
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Раздел 
    /// </summary>
    public required string Section { get; set; }
    /// <summary>
    /// Должность
    /// </summary>
    public required string PositionName { get; set; }
}
