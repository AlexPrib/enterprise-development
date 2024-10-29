using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAgency.Domain.Entity;
/// <summary>
/// Соискатель
/// </summary>
[Table("applicant")]
public class Applicant
{
    /// <summary>
    /// Идентификатор соискателя
    /// </summary>
    [Key]
    public required int Id { get; set; }
    /// <summary>
    /// ФИО соискателя
    /// </summary>
    [Column ("fullname")]
    [MaxLength (100)]
    [Required]
    public required string FullName { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    [Column ("contactinfo")]
    [MaxLength(11)]
    [Required]
    public required string ContactInformation { get; set; }
    /// <summary>
    /// Опыт работы
    /// </summary>
    [Column ("experience")]
    [MaxLength(50)]
    [Required]
    public required double Experience { get; set; }
    /// <summary>
    /// Образование
    /// </summary>
    [Column ("education")]
    [MaxLength(50)]
    [Required]
    public required string Education { get; set; }
    /// <summary>
    /// Ожидаемый уровень зарплаты
    /// </summary>
    [Column ("salaries")]
    [MaxLength(50)]
    [Required]
    public required int Salaries { get; set; }
}
