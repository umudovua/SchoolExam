using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolExam.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Persistence.Extentions
{
	public static class ServiceRegistraton
	{
		public static void AddPersistenceServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<AppDbContext>(options => 
								options.UseSqlServer(Configuration.ConnectionString,
								opt=>opt.EnableRetryOnFailure())
								);
		}
	}
}
