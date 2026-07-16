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

			builder.HasKey(oi => oi.Id).HasName("PRIMARY");

			builder.Property(oi => oi.Id)
				.HasColumnName("id")
				.IsRequired();

			builder.Property(oi => oi.OrderId)
				.HasColumnName("order_id")
				.IsRequired();

			builder.Property(oi => oi.CreatedOn)
				.HasColumnName("created_on")
				.IsRequired();

			builder.Property(oi => oi.KotNo)
				.HasColumnName("kot_no")
				.IsRequired();

			builder.Property(oi => oi.IsKotPrinted)
				.HasColumnName("is_kot_printed")
				.IsRequired();

			builder.Property(oi => oi.KotPrintedOn)
				.HasColumnName("kot_printed_on")
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(oi => oi.IsCancelKotPrinted)
				.HasColumnName("is_cancel_kot_printed")
				.IsRequired();

			builder.Property(oi => oi.CancelledKotPrintedOn)
				.HasColumnName("cancelled_kot_printed_on")
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(oi => oi.Status)
				.HasColumnName("status")
				.HasConversion<KotStatusConverter>()
				.IsRequired();

			builder.HasOne(oi => oi.RestaurantOrder)
				.WithMany(a => a.Kots)
				.HasForeignKey(oi => oi.OrderId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
