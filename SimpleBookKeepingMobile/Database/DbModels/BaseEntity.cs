using System.ComponentModel.DataAnnotations;

namespace SimpleBookKeepingMobile.Database.DbModels
{
	public abstract class BaseEntity
	{
		[Key]
		public Guid Id { get; protected set; }
	}
}
