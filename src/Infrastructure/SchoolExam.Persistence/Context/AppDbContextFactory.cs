using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SchoolExam.Persistence.Extentions;

namespace SchoolExam.Persistence.Context
{
	public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

			optionsBuilder.UseSqlServer(Configuration.ConnectionString);

			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
