using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kds.Infrastructure.Data
{
	public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			// 1. Locate the startup project folder (Kds.Api) relative to this project
			var currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
			var solutionDir = currentDir.Parent; // move up from Kds.Infrastructure to KdsSolution

			var apiProjectDir = Path.Combine(solutionDir.FullName, "Kds.WebApi");

			var appsettingsPath = Path.Combine(apiProjectDir, "appsettings.json");

			// 2. Build configuration from those files
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(apiProjectDir)
				.AddJsonFile(appsettingsPath, optional: false)
				.Build();

			// 3. Get connection string
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			if (string.IsNullOrWhiteSpace(connectionString))
			{
				throw new InvalidOperationException(
					$"Connection string 'DefaultConnection' not found. Looked in: {appsettingsPath}");
			}

			// 4. Configure DbContext for MySQL
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

			return new AppDbContext(optionsBuilder.Options);
		}
	}
}
