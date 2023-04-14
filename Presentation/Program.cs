using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;

using Domain.Interfaces.UseCaseInterfaces;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            // Add services to the container.
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EgyTourContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IGenericRepository<ServiceReview>, GenericRepository<ServiceReview>>();
            builder.Services.AddScoped<IGenericRepository<Tourist>,GenericRepository<Tourist>>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<IAddServiceReviewUseCase,AddServiceReviewUseCase>();
            builder.Services.AddScoped<ILocalReviewRepository, localReviewRepository>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<IServiceReviewRepository, ServiceReviewRepository>();
            builder.Services.AddScoped<IGenericRepository<Activity>, GenericRepository<Activity>>();
            builder.Services.AddScoped<IGenericRepository<ToDoList>, GenericRepository<ToDoList>>();
            builder.Services.AddScoped<IGenericRepository<ToDoItem>, GenericRepository<ToDoItem>>();
            builder.Services.AddScoped<IGenericRepository<LocalPerson>, GenericRepository<LocalPerson>>();



            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                                  });
            });


            var app = builder.Build(); 
            
            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseStaticFiles();
            app.UseAuthorization();

            app.MapControllers();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "api";
            });
            app.Run();
        }
    }
}