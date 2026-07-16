using Kds.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Configuration
{
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable("order_item");

			builder.HasKey(oi => oi.Id);
			builder.Property(oi => oi.Id)
				.HasColumnName("id")
				.IsRequired();

			builder.Property(oi => oi.OrderId)
				.HasColumnName("order_id")
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

			builder.HasOne(oi => oi.MenuItem)
				.WithMany()
				.HasForeignKey(oi => oi.MenuItemId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(a => a.Order)
				.WithMany(a => a.OrderItems)
				.HasForeignKey(a => a.OrderId) 
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
