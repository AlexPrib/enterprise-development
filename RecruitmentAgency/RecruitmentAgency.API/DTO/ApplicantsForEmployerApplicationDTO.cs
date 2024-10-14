using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.DTO;
/// <summary>
/// DTO описывающее соискателя и заявку работодателя
/// </summary>
public class ApplicantsForEmployerApplicationDTO
{
    /// <summary>
    /// Соискатель
    /// </summary>
    public required Applicant applicant;
    /// <summary>
    /// Заявка работодателя
    /// </summary>
    public required EmployerApplication EmployerApp;
}
