namespace Xpense.Extension.Core.Entities
{
    public class Expense
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public DateTime SpentAt { get; set; }
        public long ExpenseCategoryId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; } = null!;
    }
}
