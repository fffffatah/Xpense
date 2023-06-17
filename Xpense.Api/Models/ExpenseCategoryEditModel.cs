using System.ComponentModel.DataAnnotations;

namespace Xpense.Api.Models
{
    public class ExpenseCategoryEditModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "* Category Name is required")]
        public string Name { get; set; }
    }
}
