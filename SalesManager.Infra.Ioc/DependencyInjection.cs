using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesManager.Infra.Data.Context;
using SalesManager.Infra.Data.Interfaces;
using SalesManager.Infra.Data.Repositories;

namespace SalesManager.Infra.Ioc
{
	public static class DependencyInjection
	{
		public static IServiceCollection InjectDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("MySQL") ?? throw new InvalidDataException("No MySQL Connection");

			services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseMySql(connectionString,
					ServerVersion.AutoDetect(connectionString),
					options => options.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName));
			});

			// Repositories
			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}
	}
}

