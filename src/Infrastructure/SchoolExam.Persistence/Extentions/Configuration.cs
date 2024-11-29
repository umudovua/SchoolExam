using Microsoft.Extensions.Configuration;

namespace SchoolExam.Persistence.Extentions
{
	public static class Configuration
	{
		public static string ConnectionString
		{
			get
			{
				ConfigurationManager configurationManager = new();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/SchoolExam.API"));
				configurationManager.AddJsonFile("appsettings.json");

				return configurationManager.GetConnectionString("DefaultConnection");
			}
		}
	}
}
	