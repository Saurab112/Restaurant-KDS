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

			builder.HasKey(o => o.OrderId).HasName("PRIMARY");
			builder.Property(o => o.OrderId)
				.HasColumnName("order_id")
				.IsRequired();

			builder.Property(o => o.TableNumber)
				.HasColumnName("table_number")
				.HasMaxLength(50)
				.IsRequired(false);

			builder.Property(o => o.OrderType)
				.HasColumnName("order_type")
				.HasConversion<OrderTypeConverter>()
				.IsRequired();

			builder.Property(o => o.Status)
				.HasColumnName("status")
				.HasConversion<OrderStatusConverter>()
				.IsRequired();

			builder.Property(o => o.CreatedOn)
				.HasColumnName("created_on")
				.IsRequired();

		}
	}
}
