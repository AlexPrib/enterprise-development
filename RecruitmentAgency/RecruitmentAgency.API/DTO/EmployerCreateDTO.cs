namespace RecruitmentAgency.API.DTO;

/// <summary>
/// DTO для создания работодателя
/// </summary>
public class EmployerCreateDTO
{
    /// <summary>
    /// Название компании
    /// </summary>
    public required string CompanyName { get; set; }
    /// <summary>
    /// ФИО контактного лица
    /// </summary>
    public required string ContactPersonName { get; set; }
    /// <summary>
    /// Телефон работодателя
    /// </summary>
    public required string CompanyNumber { get; set; }
}
