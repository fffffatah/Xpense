namespace Xpense.Api.Models;

public class ExpenseViewModel
{
    public long Id { get; set; }
    public double Amount { get; set; }
    public DateTime SpentAt { get; set; }
    public long ExpenseCategoryId { get; set; }
}