using RecruitmentAgency.API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<ApplicantApplicationService>();
builder.Services.AddSingleton<ApplicantsService>();
builder.Services.AddSingleton<EmployerApplicationService>();
builder.Services.AddSingleton<EmployerService>();
builder.Services.AddSingleton<PositionService>();
builder.Services.AddSingleton<QueryService>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
