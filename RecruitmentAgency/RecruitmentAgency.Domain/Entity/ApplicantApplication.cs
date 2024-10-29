using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAgency.Domain.Entity;
/// <summary>
/// Заявка соискателя
/// </summary>
[Table("applicant_application")]
public class ApplicantApplication
{
    /// <summary>
    /// Идентификатор заявки соискателя
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
    /// Соискатель 
    /// </summary>
    [Column("applicant_id")]
    [Required]
    public required Applicant Applicant { get; set; }
    /// <summary>
    /// Должность 
    /// </summary>
    [Column("position_id")]
    [Required]
    public required Position Position { get; set; }

}
