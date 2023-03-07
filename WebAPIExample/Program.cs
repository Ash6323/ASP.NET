namespace WebAPIExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

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

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Getting Response from 1st Middleware \n");
                await next();
            });

            app.Run(async context => 
            {
                await context.Response.WriteAsync("Response Response from second Middleware \n");
            });

            app.Run();
        }
    }
}