using JobMap.API.Persistence.Data;
using JobMap.API.Repositories.Contracts;
using JobMap.API.Repositories.Implementation;
using JobMap.API.Services.Contracts;
using JobMap.API.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Repositories and Services
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();


//Inject DBContext dependencies into the application
builder.Services.AddDbContext<JobMapDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("JobMapDefaultConnection")));

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
