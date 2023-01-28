using System.ComponentModel.DataAnnotations;

namespace Xpense.Models
{
    public class ExpenseCategoryAddModel
    {
        [Required(ErrorMessage = "* Category Name is required")]
        public string Name { get; set; }
    }
}
