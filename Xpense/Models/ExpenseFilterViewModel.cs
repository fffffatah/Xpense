using System.ComponentModel.DataAnnotations;

namespace Xpense.Models
{
    public class ExpenseFilterViewModel
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public DateTime SpentAt { get; set; }
        public long ExpenseCategoryId { get; set; }

        [Required(ErrorMessage = "* Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "* End Date is required")]
        public DateTime EndDate { get; set; }
    }
}
