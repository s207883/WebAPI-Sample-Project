using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using WebApiSample.BLL;
using WebApiSample.BLL.Implemetations;
using WebApiSample.BLL.Interfaces;
using WebApiSample.Core.AutomapperProfiles;
using WebApiSample.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApiSample.WebApp
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddDbContext<MainContext>
				(
					options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LogroconDB;Integrated Security=true;"
				));

			services.AddScoped<IPositionRepository, PositionRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IEployeePositionRepository, EployeePositionRepository>();

			services.AddScoped<RepoManager>();

			var mappingConfig = new MapperConfiguration(mc =>
		  {
			  mc.AddProfile(new PositionProfile());
			  mc.AddProfile(new EmployeeProfile());
			  mc.AddProfile(new EmployeePositionProfile());
		  });

			var mapper = mappingConfig.CreateMapper();

			services.AddSingleton(mapper);

			services.AddSwaggerGen(sg =>
			{
				sg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Version = "v1",
					Title = "Web API",
				});
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				sg.IncludeXmlComments(xmlPath);
			});
		}

		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
		  {
			  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
		  });

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
