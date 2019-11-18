using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTZ.BLL;
using LogTZ.BLL.Implemetations;
using LogTZ.BLL.Interfaces;
using LogTZ.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LogTZ.WebApp
{
	public class Startup
	{
		public Startup ( IConfiguration configuration )
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public static void ConfigureServices ( IServiceCollection services )
		{
			services.AddControllers ( );

			services.AddDbContext<MainContext>
				(
					options => options.UseSqlServer( @"Server=(localdb)\mssqllocaldb;Database=LogroconDB;Integrated Security=true;"
				));

			services.AddScoped<IPositionRepository, PositionRepository> ( );
			services.AddScoped<IEmployeeRepository, EmployeeRepository> ( );
			services.AddScoped<IEployeePositionRepository, EployeePositionRepository> ( );

			services.AddSingleton<RepoManager> ( );

			services.AddSwaggerGen(sg =>
			{
				sg.SwaggerDoc ( "v1", new Microsoft.OpenApi.Models.OpenApiInfo {
					Version = "v1",
					Title = "Web API",
				} );
			} );
		}

		public static void Configure ( IApplicationBuilder app, IWebHostEnvironment env )
		{
			if ( env.IsDevelopment ( ) )
			{
				app.UseDeveloperExceptionPage ( );
			}

			app.UseRouting ( );

			app.UseAuthorization ( );

			app.UseSwagger();
			app.UseSwaggerUI ( c =>
			{
				c.SwaggerEndpoint ( "/swagger/v1/swagger.json", "Web API V1" );
			} );

			app.UseEndpoints ( endpoints =>
			  {
				  endpoints.MapControllers ( );
			  } );
		}
	}
}
