using Kds.Domain.Entities;
using Kds.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Configuration
{
	public class KotConfiguration : IEntityTypeConfiguration<Kot>
	{
		public void Configure(EntityTypeBuilder<Kot> builder)
		{
			builder.ToTable("kot");

			builder.HasKey(k => k.Id)
				.HasName("PRIMARY");

			builder.Property(k => k.Id)
				.HasColumnName("id")
				.IsRequired();

			builder.Property(k => k.OrderId)
				.HasColumnName("order_id")
				.IsRequired();

			builder.Property(k => k.CreatedOn)
				.HasColumnName("created_on")
				.IsRequired();

			builder.Property(k => k.KotNo)
				.HasColumnName("kot_no")
				.IsRequired();

			builder.Property(k => k.Status)
				.HasColumnName("status")
				.HasConversion<KotStatusConverter>()
				.IsRequired();

			builder.Property(k => k.KotPreparationStartedOn)
				.HasColumnName("kot_preparation_started_on")
				.IsRequired(false);

			builder.Property(k => k.KotReadyOn)
				.HasColumnName("kot_ready_on")
				.IsRequired(false);

			builder.Property(k => k.KotCancelledOn)
				.HasColumnName("kot_cancelled_on")
				.IsRequired(false);

			builder.Property(k => k.KotCompletedOn)
				.HasColumnName("kot_completed_on")
				.IsRequired(false);

			builder.HasOne(k => k.RestaurantOrder)
				.WithMany(o => o.Kots)
				.HasForeignKey(k => k.OrderId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(k => k.OrderItems)
				.WithOne(oi => oi.Kot)
				.HasForeignKey(oi => oi.KotId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
