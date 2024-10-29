using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentAgency.Domain.Entity;
/// <summary>
/// Должность
/// </summary>
[Table("position")]
public class Position
{
    /// <summary>
    /// Идентификатор должности
    /// </summary>
    [Key]
    public required int Id { get; set; }
    /// <summary>
    /// Раздел 
    /// </summary>
    [Column("section")]
    [Required]
    public required string Section { get; set; }
    /// <summary>
    /// Должность
    /// </summary>
    [Column("position_name")]
    [Required]
    public required string PositionName { get; set; }
}
