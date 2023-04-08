using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();

            // Add services to the container.
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<EgyTourContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IGenericRepository<TouristFriend>, GenericRepository<TouristFriend>>();
            builder.Services.AddScoped<IGenericRepository<Tourist>, GenericRepository<Tourist>>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IJwtProvider, JwtProvider>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
                });
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}