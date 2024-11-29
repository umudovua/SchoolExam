using SchoolExam.Infrastructure;
using SchoolExam.Persistence.Extentions;
using SchoolExam.Application.Extentions;

namespace SchoolExam.API.Extentions
{
	public static class AppServiceRegistration
	{
		public static void AddAppServiceRegistration(this IServiceCollection services, IConfiguration config)
		{
			services.AddApplicationRegistration(config);
			services.AddInfrastructurService(config);
			services.AddPersistenceServices(config);

		}
	}
}
