using System.Reflection;
using CustomerLocationRP.Services.Interfaces;
using CustomerLocationRP.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerLocationRP.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                // generate the XML docs that'll drive the swagger docs
                var xmlFile = $" {Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments("E:\\Work\\IncubXperts\\ASP.NET\\CustomerLocationRP.WebAPI\\bin\\Debug\\net6.0\\xml-documentation.xml");
            });

            builder.Services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDbContext"));
            });

            builder.Services.AddScoped<ICustomer, CustomerService>();

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
        }
    }
}