using RecruitmentAgency.API.DTO;
using RecruitmentAgency.API.Mapper;
using RecruitmentAgency.API.Services;
using RecruitmentAgency.Domain.Context;
using RecruitmentAgency.Domain.Entity;
using RecruitmentAgency.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddDbContext<RecruitmentAgencyContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 38))));


builder.Services.AddScoped<IEntityRepository<Applicant>, ApplicantRepository>();
builder.Services.AddScoped<IEntityRepository <Employer>, EmployerRepository>();
builder.Services.AddScoped<IEntityRepository<Position>, PositionRepository>();
builder.Services.AddScoped<IEntityRepository<ApplicantApplication>, ApplicantApplicationRepository>();
builder.Services.AddScoped<IEntityRepository<EmployerApplication>, EmployerApplicationRepository>();

builder.Services.AddScoped<IEntityService<ApplicantDTO, ApplicantCreateDTO>, ApplicantsService>();
builder.Services.AddScoped<IEntityService<EmployerDTO, EmployerCreateDTO>, EmployerService>();
builder.Services.AddScoped<IEntityService<PositionDTO, PositionCreateDTO>, PositionService>();
builder.Services.AddScoped<IEntityService<ApplicantApplicantDTO, ApplicantApplicationCreateDTO>, ApplicantApplicationService>();
builder.Services.AddScoped<IEntityService<EmployerApplicationDTO, EmployerApplicationCreateDTO>, EmployerApplicationService>();

builder.Services.AddScoped<IQueryService, QueryService>();


builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
