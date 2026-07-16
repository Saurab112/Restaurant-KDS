using Kds.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Converters
{
	public class KotStatusConverter: ValueConverter<KotStatusEnum, int>
	{
		public KotStatusConverter()
			:base(
				 status => status.Id,
				 id => ConvertToKotStatus(id)
			)
		{
		}

		private static KotStatusEnum ConvertToKotStatus(int id) => id switch
		{
			1 => KotStatusEnum.Pending,
			2 => KotStatusEnum.Preparing,
			3 => KotStatusEnum.Ready,
			4 => KotStatusEnum.Completed,
			5 => KotStatusEnum.Cancelled,
			_ => throw new ArgumentOutOfRangeException(nameof(id), $"Unknown Kot Status ID: {id}")
		};
	}
}
