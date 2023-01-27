namespace Xpense.Models
{
    public class ExpenseViewModel
    {
        public long Id { get; set; }
        public double Amount { get; set; }
        public DateTime SpentAt { get; set; }
        public string Category { get; set; }
    }
}
