using Kds.Domain.Entities;
using Kds.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("order");

			builder.HasKey(o => o.Id);
			builder.Property(o => o.Id)
				.HasColumnName("id")
				.IsRequired();

			builder.Property(o => o.TicketNumber)
				.HasColumnName("ticket_number")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(o => o.TableNumber)
				.HasColumnName("table_number")
				.HasMaxLength(50)
				.IsRequired(false);

			builder.Property(o => o.OrderType)
				.HasColumnName("order_type_id")
				.HasConversion<OrderTypeConverter>()
				.IsRequired();

			builder.Property(o => o.Status)
				.HasColumnName("order_status_id")
				.HasConversion<OrderStatusConverter>()
				.IsRequired();

			builder.Property(o => o.CreatedAt)
				.HasColumnName("created_at")
				.IsRequired();

			builder.HasMany(o => o.OrderItems)
				.WithOne(oi => oi.Order)
				.HasForeignKey(oi => oi.OrderId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(o => o.OrderTimelines)
				.WithOne(ot => ot.Order)
				.HasForeignKey(ot => ot.OrderId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
