namespace Xpense.Models
{
    public class ExpenseUpdateModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime SpentAt { get; set; }

    }
}
