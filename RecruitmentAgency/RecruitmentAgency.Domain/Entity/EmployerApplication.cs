using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAgency.Domain.Entity;
/// <summary>
/// Заявка работодателя
/// </summary>
[Table("employer_application")]
public class EmployerApplication
{
    /// <summary>
    /// Идентификатор заявки работодателя
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Дата подачи
    /// </summary>
    [Column("submission_date")]
    [Required]
    public required DateTime SubmissionDate { get; set; }
    /// <summary>
    /// Работодатель
    /// </summary>
    [Column("employer_id")]
    [Required]
    public required Employer Employer { get; set; }
    /// <summary>
    /// Должность
    /// </summary>
    [Column("position_id")]
    [Required]
    public required Position Position { get; set; }
    /// <summary>
    /// Требование 
    /// </summary>
    [Column("requirements")]
    [Required]
    public required string Requirements { get; set; }
    /// <summary>
    /// Предлагаемый уровень зарплаты
    /// </summary>
    [Column("offered_salary")]
    [Required]
    public required int OfferedSalary { get; set; }
}
