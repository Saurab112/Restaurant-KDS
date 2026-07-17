using Kds.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Converters
{
	public class KotStatusConverter : ValueConverter<KotStatusEnum, string>
	{
		public KotStatusConverter() : base(
			v => v.Name,
			v => KotStatusEnum.FromName(v))
		{
		}
	}
}
