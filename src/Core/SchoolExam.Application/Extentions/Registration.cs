using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.Extentions
{
	public static class Registration
	{
		public static IServiceCollection AddApplicationRegistration(this IServiceCollection services, IConfiguration configuration)
		{
			var assembly = Assembly.GetExecutingAssembly();

			services.AddAutoMapper(assembly);
			services.AddValidatorsFromAssembly(assembly);

			return services;
		}
	}
}
