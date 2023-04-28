using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTeacher.Data.Context;
using StudentTeacher.Data.Models;
using StudentTeacher.Data.Mappings;
using StudentTeacher.Service.Filters;
using StudentTeacher.Service.Interfaces;
using StudentTeacher.Service.Services;
using NLog;

var builder = WebApplication.CreateBuilder(args);

//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LoggerManager logger = new LoggerManager();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentTeacherDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentTeacherConnection"));
});

//Extensions...

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
var mapperConfig = new MapperConfiguration(map =>
{
    map.AddProfile<TeacherMappingProfile>();
    map.AddProfile<StudentMappingProfile>();
    map.AddProfile<UserMappingProfile>();
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddIdentity<User, IdentityRole>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<StudentTeacherDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication();

//Register Dependencies
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<ValidationFilterAttribute>();
//builder.Services.AddScoped<ValidateTeacherExists>();
//builder.Services.AddScoped<ValidateStudentExistsForTeacher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
