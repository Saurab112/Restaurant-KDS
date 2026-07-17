using Kds.Domain.Entities;
using Kds.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Kds.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Order> Orders => Set<Order>();
		public DbSet<OrderItem> OrderItems => Set<OrderItem>();
		public DbSet<MenuItem> MenuItems => Set<MenuItem>();
		public DbSet<Kot> Kots => Set<Kot>();
		public DbSet<Sequence> Sequences => Set<Sequence>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder
				.UseCollation("utf8mb4_unicode_ci")
				.HasCharSet("utf8mb4");

			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
			modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
			modelBuilder.ApplyConfiguration(new KotConfiguration());
			modelBuilder.ApplyConfiguration(new SequenceConfiguration());
		}
	}
}
