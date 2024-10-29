using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAgency.Domain.Entity;
///<summary>
///Работодатель
///</summary>
[Table("employer")]
public class Employer
{
    /// <summary>
    /// Идентификатор работадателя
    /// </summary>
    [Key]
    public required int Id { get; set; }
    /// <summary>
    /// Название компании
    /// </summary>
    [Column("company_name")]
    [StringLength(50)]
    [Required]
    public required string CompanyName { get; set; }
    /// <summary>
    /// ФИО контактного лица
    /// </summary>
    [Column("contact_person_name")]
    [StringLength(50)]
    [Required]
    public required string ContactPersonName { get; set; }
    /// <summary>
    /// Телефон работодателя
    /// </summary>
    [Column("company_number")]
    [StringLength(11)]
    [Required]
    public required string CompanyNumber { get; set; }
}
