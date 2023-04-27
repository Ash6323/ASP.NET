using Lexicon.Data.Context;
using Microsoft.EntityFrameworkCore;
using Lexicon.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LexiconDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LexiconConnection"));
});

builder.Services.AddScoped<IJurisdiction, JurisdictionService>();
builder.Services.AddScoped<IAttorney, AttorneyService>();
builder.Services.AddScoped<IMatter, MatterService>();
builder.Services.AddScoped<IClient, ClientService>();
builder.Services.AddScoped<IInvoice, InvoiceService>();

builder.Services.AddCors(o => o.AddPolicy("ReactPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
