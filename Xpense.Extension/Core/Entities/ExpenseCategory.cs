using System.ComponentModel.DataAnnotations;

namespace Xpense.Extension.Core.Entities
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
