using Kds.Domain.Entities;
using Kds.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kds.Infrastructure.Persistence.Configuration
{
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable("order_item");

			builder.HasKey(oi => oi.Id)
				.HasName("PRIMARY");

			builder.Property(oi => oi.Id)
				.HasColumnName("id")
				.IsRequired();

			builder.Property(oi => oi.OrderId)
				.HasColumnName("order_id")
				.IsRequired();

			builder.Property(oi => oi.KotId)
				.HasColumnName("kot_id")
				.IsRequired();

			builder.Property(oi => oi.MenuItemId)
				.HasColumnName("menu_item_id")
				.IsRequired();

			builder.Property(oi => oi.Quantity)
				.HasColumnName("quantity")
				.IsRequired();

			builder.Property(oi => oi.Remarks)
				.HasColumnName("remarks")
				.HasMaxLength(500)
				.IsRequired(false);

			builder.Property(oi => oi.CreatedOn)
				.HasColumnName("created_on")
				.IsRequired();

			builder.Property(oi => oi.Status)
				.HasColumnName("status")
				.HasConversion<OrderItemStatusConverter>()
				.IsRequired();

			builder.Property(oi => oi.CancelledOn)
				.HasColumnName("cancelled_on")
				.IsRequired(false);

			builder.HasOne(oi => oi.MenuItem)
				.WithMany()
				.HasForeignKey(oi => oi.MenuItemId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(oi => oi.Order)
				.WithMany(o => o.OrderItems)
				.HasForeignKey(oi => oi.OrderId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(oi => oi.Kot)
				.WithMany(k => k.OrderItems)
				.HasForeignKey(oi => oi.KotId)
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
