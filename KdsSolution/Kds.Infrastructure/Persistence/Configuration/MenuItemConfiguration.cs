using Kds.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Configuration
{
	public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
	{
		public void Configure(EntityTypeBuilder<MenuItem> builder)
		{
			builder.ToTable("menu_item");

			builder.HasKey(m => m.Id).HasName("PRIMARY");
			builder.Property(m => m.Id)
				.HasColumnName("id");

			builder.Property(m => m.Name)
				.HasColumnName("menu_item_name")
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(m => m.Category)
				.HasColumnName("category") 
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(m => m.Price)
				.HasColumnName("price")
				.HasPrecision(18, 2)
				.IsRequired();
		}
	}
}
