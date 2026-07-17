using Kds.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Configuration
{
	public class SequenceConfiguration : IEntityTypeConfiguration<Sequence>
	{
		public void Configure(EntityTypeBuilder<Sequence> builder)
		{
			builder.ToTable("sequence");
			builder.HasKey(e => e.SequenceId);
			builder.Property(e => e.SequenceId).HasColumnName("sequence_id").IsRequired();
			builder.Property(e => e.SequenceKey).HasColumnName("sequence_key").IsRequired();
			builder.Property(e => e.SequenceGroup).HasColumnName("sequence_group").IsRequired();
			builder.Property(e => e.SequenceValue).HasColumnName("sequence_value").IsRequired();
		}
	}
	}
