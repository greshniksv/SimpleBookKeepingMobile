using System.ComponentModel.DataAnnotations;

namespace SimpleBookKeepingMobile.DtoModels
{
    public class AddCreditSpendModel
    {
	    [Required]
		public Guid CostId { get; set; }

        public Guid? Id { get; set; }

        [Required]
        public Guid CostDetailId { get; set; }

        [RegularExpression(@"[\+-]?[0-9]{1,}")]
        public int Value { get; set; }

		[MaxLength(300)]
        public string Comment { get; set; }

		[Range(1, 500)]
        public int Days { get; set; }
    }
}