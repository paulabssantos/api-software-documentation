using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.src.Infra.Data.Context;
using api_software_documentation.src.Infra.Data.Repository;
using api_software_documentation.src.Service.Services;
using api_software_documentation.Src.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database connection
var connectionString = builder.Configuration["ConnectionStrings:SoftwareDocumentationConnection"];
builder.Services.AddDbContext<MySqlContext>(opts => opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add services to the container.

//Dependency Injection
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<CreateProjectService>();
builder.Services.AddScoped<IProjectCharterRepository, ProjectCharterRepository>();
builder.Services.AddScoped<CreateProjectCharterService>();
builder.Services.AddScoped<IUserRequirementRepository, UserRequirementRepository>();
builder.Services.AddScoped<CreateUserRequirementsService>();
//Libraries
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Controllers
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
