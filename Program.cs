using FFImageLoading;
using Microsoft.EntityFrameworkCore;
using signinapi.Models;
using signupapi.Models;

namespace signupapi
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


            var connectionString = "server=127.0.0.1;port=3306;database=User;user=root;password=root";
            var serverVersion = new MariaDbServerVersion(new Version(10, 6, 4));
            builder.Services.AddDbContext<SigninContext>(options => options.UseMySql(connectionString, serverVersion));
            builder.Services.AddDbContext<SignupContext>(options => options.UseMySql(connectionString, serverVersion));
            builder.Services.AddDbContext<ProfileInformationContext>(options => options.UseMySql(connectionString, serverVersion));





            var app = builder.Build();

            app.UseCors(policy => policy.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

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