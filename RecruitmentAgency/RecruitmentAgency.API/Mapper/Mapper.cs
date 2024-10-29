using AutoMapper;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain.Entity;

namespace RecruitmentAgency.API.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Applicant, ApplicantCreateDTO>().ReverseMap();
        CreateMap<Applicant, ApplicantDTO>().ReverseMap();
        CreateMap<ApplicantApplication, ApplicantApplicationCreateDTO>().ReverseMap();
        CreateMap<ApplicantApplication, ApplicantApplicantDTO>().ReverseMap();
        CreateMap<Employer, EmployerCreateDTO>().ReverseMap();
        CreateMap<Employer, EmployerDTO>().ReverseMap();
        CreateMap<EmployerApplication, EmployerApplicationCreateDTO>().ReverseMap();
        CreateMap<EmployerApplication, EmployerApplicationDTO>().ReverseMap();
        CreateMap<Position, PositionCreateDTO>().ReverseMap();
        CreateMap<Position, PositionDTO>().ReverseMap();
    }
}
