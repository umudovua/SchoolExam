using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Application.Interfaces.Repositories.Base;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Infrastructure.Repositories;
using SchoolExam.Infrastructure.Services;

namespace SchoolExam.Infrastructure
{
	public static class InfrastructureConfigureService
	{
		public static IServiceCollection AddInfrastructurService(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddScoped<ILessonRepository, LessonRepository>();
			services.AddScoped<IClassRoomRepository, ClassRoomRepository>();
			services.AddScoped<IExamRepository, ExamRepository>();
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<ITeacherRepository, TeacherRepository>();

			services.AddScoped<ILessonService, LessonService>();
			services.AddScoped<IClassRoomService, ClassRoomService>();
			services.AddScoped<IExamService, ExamService>();
			services.AddScoped<IStudentService, StudentService>();
			services.AddScoped<ITeacherService, TeacherService>();
			return services;

		}
	}
}
