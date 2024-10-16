namespace RecruitmentAgency.API.DTO;
/// <summary>
/// DTO описывающее соискателя и заявку работодателя
/// </summary>
public class ApplicantsForEmployerApplicationDTO
{
    /// <summary>
    /// Соискатель
    /// </summary>
    public required int ApplicantId { get; set; }
    /// <summary>
    /// Заявка работодателя
    /// </summary>
    public required int EmployerAppId { get; set; }
}
