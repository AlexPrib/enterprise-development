﻿namespace RecruitmentAgency.Domain;
/// <summary>
/// Соискатель
/// </summary>
public class Applicant
{
    /// <summary>
    /// Идентификатор соискателя
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// ФИО соискателя
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    public required string ContactInformation { get; set; }
    /// <summary>
    /// Опыт работы
    /// </summary>
    public required double Experience { get; set; }
    /// <summary>
    /// Образование
    /// </summary>
    public required string Education { get; set; }
    /// <summary>
    /// Ожидаемый уровень зарплаты
    /// </summary>
    public required int Salaries { get; set; }
}
