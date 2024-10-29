using AutoMapper;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain.Entity;
using RecruitmentAgency.Domain.Repositories;

namespace RecruitmentAgency.API.Services;

public class QueryService(IEntityRepository<ApplicantApplication> applicantapplicationRepository, IEntityRepository<EmployerApplication> employerapplicationRepository, IMapper mapper) : IQueryService
{
    public List<ApplicantDTO> GetAllApplicantsByPositionOrderedByFullName(string positionName)
    {
        return [.. applicantapplicationRepository.GetAll()
            .Where(a => a.Position.PositionName == positionName)
            .Select(a => mapper.Map<ApplicantDTO>(a.Applicant))
            .OrderBy(a => a.FullName)];
    }

    public List<ApplicantDTO> GetAllApplicantsBySubmissionDateRange(DateTime startDate, DateTime endDate)
    {
        return applicantapplicationRepository.GetAll()
            .Where(a => a.SubmissionDate >= startDate && a.SubmissionDate <= endDate)
            .Select(a => mapper.Map<ApplicantDTO>(a.Applicant))
            .ToList();
    }


    public List<ApplicantsForEmployerApplicationDTO> GetApplicantsForEmployerApplication(int employerApplicationId)
    {
        var applicantApplications = applicantapplicationRepository.GetAll()
            .Where(app => app.Position != null) 
            .ToList();

        var employerApplications = employerapplicationRepository.GetAll()
            .ToList(); 

        var applicantsForEmployer = applicantApplications
            .Join(employerApplications,
                  applicantApp => applicantApp.Position.Id, 
                  employerApp => employerApp.Position.Id,
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
        var applicantApplications = applicantapplicationRepository.GetAll()
                .GroupBy(app => new { app.Position.Section, app.Position.PositionName })
                .Select(group => new
                {
                    group.Key.Section,
                    group.Key.PositionName,
                    ApplicantApplicationsCount = group.Count()
                });

        var employerApplications = employerapplicationRepository.GetAll()
            .GroupBy(emp => new { emp.Position.Section, emp.Position.PositionName })
            .Select(group => new
            {
                group.Key.Section,
                group.Key.PositionName,
                EmployerApplicationsCount = group.Count()
            });

        var combinedStatistics = applicantApplications
            .GroupJoin(employerApplications,
                       applicantApp => new { applicantApp.Section, applicantApp.PositionName },
                       employerApp => new { employerApp.Section, employerApp.PositionName },
                       (applicantApp, employerApps) => new
                       {
                           applicantApp.Section,
                           applicantApp.PositionName,
                           applicantApp.ApplicantApplicationsCount,
                           EmployerApplicationsCount = employerApps.Sum(e => e.EmployerApplicationsCount)
                       })
            .Select(stat => new ApplicationStatisticsDTO
            {
                Section = stat.Section,
                PositionName = stat.PositionName,
                ApplicantApplicationsCount = stat.ApplicantApplicationsCount,
                EmployerApplicationsCount = stat.EmployerApplicationsCount
            })
            .OrderBy(stat => stat.Section)
            .ThenBy(stat => stat.PositionName)
            .ToList();

        return combinedStatistics;
    }

    public List<TopEmployerDTO> GetTopEmployersByApplications()
    {
        var topEmployers = employerapplicationRepository.GetAll()
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

    public List<EmployerDTO> GetEmployersWithMaxSalaryApplications()
    {
        var employerApplications = employerapplicationRepository.GetAll();

        if (!employerApplications.Any())
        {
            return [];
        }

        var maxSalary = employerApplications.Max(e => e.OfferedSalary);

        return employerApplications
            .Where(e => e.OfferedSalary == maxSalary)
            .Select(e => mapper.Map<EmployerDTO>(e.Employer))
            .Distinct()
            .ToList();
    }
}
