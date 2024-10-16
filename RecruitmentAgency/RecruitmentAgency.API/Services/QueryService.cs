using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Services;

public class QueryService(ApplicantApplicationService applicantapplicationService, EmployerApplicationService employerapplicationService)
{
    public List<Applicant> GetAllApplicantsByPositionOrderedByFullName(string positionName)
    {
        var sortedApplicant = applicantapplicationService.GetAll()
            .Where(a => a.Position.PositionName == positionName)
            .Select(a => a.Applicant)
            .OrderBy(a => a.FullName)
            .ToList();
        return sortedApplicant;
    }

    public List<Applicant> GetAllApplicantsBySubmissionDateRange(DateTime startDate, DateTime endDate)
    {
        var applicantsInRange = applicantapplicationService.GetAll()
            .Where(a => a.SubmissionDate >= startDate && a.SubmissionDate <= endDate)
            .Select(a => a.Applicant)
            .ToList();
        return applicantsInRange;
    }

    public List<ApplicantsForEmployerApplicationDTO> GetApplicantsForEmployerApplication(int employerApplicationId)
    {
        var applicantsForEmployer = applicantapplicationService.GetAll()
            .Join(employerapplicationService.GetAll(),
                  applicantApp => applicantApp.Position,
                  employerApp => employerApp.Position,
                  (applicantApp, employerApp) => new { ApplicantApp = applicantApp, EmployerApp = employerApp })
            .Where(a => a.EmployerApp.Id == employerApplicationId &&
                        a.ApplicantApp.Applicant.Salaries <= a.EmployerApp.OfferedSalary)
            .Select(a => new ApplicantsForEmployerApplicationDTO
            {
                ApplicantId = a.ApplicantApp.Applicant.Id,
                EmployerAppId = a.EmployerApp.Id
            })
            .ToList();

        return applicantsForEmployer;
    }


    public List<ApplicationStatisticsDTO> GetApplicationCountBySectionAndPositionAll()
    {
        var applicationStatistics = applicantapplicationService.GetAll()
            .GroupJoin(employerapplicationService.GetAll(),
                       applicantApp => applicantApp.Position,
                       employerApp => employerApp.Position,
                       (applicantApp, employerApps) => new { ApplicantApp = applicantApp, EmployerApps = employerApps })
            .SelectMany(
                x => x.EmployerApps.DefaultIfEmpty(),
                (applicantGroup, employerApp) => new { applicantGroup.ApplicantApp, EmployerApp = employerApp })
            .GroupBy(g => new { g.ApplicantApp.Position.Section, g.ApplicantApp.Position.PositionName })
            .Select(group => new ApplicationStatisticsDTO
            {
                Section = group.Key.Section,
                PositionName = group.Key.PositionName,
                EmployerApplicationsCount = group.Count(g => g.EmployerApp != null),
                ApplicantApplicationsCount = group.Count(g => g.ApplicantApp != null)
            })
            .OrderBy(stat => stat.Section)
            .ThenBy(stat => stat.PositionName)
            .ToList();

        return applicationStatistics;
    }

    public List<TopEmployerDTO> GetTopEmployersByApplications()
    {
        var topEmployers = employerapplicationService.GetAll()
            .GroupBy(employerApp => employerApp.Id)
            .Select(group => new TopEmployerDTO
            {
                EmployerId = group.Key,
                EmployerName = group.FirstOrDefault()?.Employer?.ContactPersonName ?? "Неизвестный работодатель",
                ApplicationsCount = group.Count()
            })
            .OrderByDescending(e => e.ApplicationsCount)
            .Take(5)
            .ToList();

        return topEmployers;
    }

    public List<Employer> GetEmployersWithMaxSalaryApplications()
    {
        var maxSalary = employerapplicationService.GetAll().Max(e => e.OfferedSalary);
        var employersWithMaxSalary = employerapplicationService.GetAll()
            .Where(e => e.OfferedSalary == maxSalary)
            .Select(e => e.Employer)
            .Distinct()
            .ToList();

        return employersWithMaxSalary;
    }
}
