using System.ComponentModel.DataAnnotations;
using Xpense.CustomAttributes;

namespace Xpense.Models
{
    public class ExpenseAddModel
    {
        [Required(ErrorMessage = "* Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "* Please enter valid amount")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "* Spent At Date is required")]
        [ValidateDateRange]
        public DateTime SpentAt { get; set; }

        [Required(ErrorMessage = "* Please pick a category")]
        public string Category { get; set; }
    }
}
