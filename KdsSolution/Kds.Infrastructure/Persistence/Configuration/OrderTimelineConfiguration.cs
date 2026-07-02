using Kds.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Configuration
{
	public class OrderTimelineConfiguration
	{
		public void Configure(EntityTypeBuilder<OrderTimeline> builder)
		{
			builder.ToTable("order_timeline");

			builder.HasKey(ot => ot.Id);
			builder.Property(ot => ot.Id)
				.HasColumnName("id")
				.IsRequired();

			builder.Property(ot => ot.OrderId)
				.HasColumnName("order_id")
				.IsRequired();

			builder.Property(ot => ot.FromStatus)
				.HasColumnName("from_status")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(ot => ot.ToStatus)
				.HasColumnName("to_status")
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(ot => ot.ChangedAt)
				.HasColumnName("changed_at")
				.IsRequired();

			builder.HasOne(ot => ot.Order)
				.WithMany(o => o.OrderTimelines)
				.HasForeignKey(ot => ot.OrderId);
		}
	}
}
