namespace RecruitmentAgency.API.DTO;

/// <summary>
/// DTO для создания должности
/// </summary>
public class PositionCreateDTO
{
    /// <summary>
    /// Раздел 
    /// </summary>
    public required string Section { get; set; }
    /// <summary>
    /// Должность
    /// </summary>
    public required string PositionName { get; set; }
}
