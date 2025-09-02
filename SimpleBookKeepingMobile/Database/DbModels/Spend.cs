﻿
using Microsoft.EntityFrameworkCore;

namespace SimpleBookKeepingMobile.Database.DbModels
{
	[Index(nameof(UserId))]
	[Index(nameof(CostDetailId))]
	public class Spend : BaseEntity
	{
		public Guid UserId { get; set; }

		public Guid CostDetailId { get; set; }

		public CostDetail CostDetail { get; set; }

		public int OrderId { get; set; }

		public int? Value { get; set; }

		public string Comment { get; set; }

		public string Image { get; set; }
	}
}
