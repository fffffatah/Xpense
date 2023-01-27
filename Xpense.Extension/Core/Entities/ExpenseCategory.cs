﻿namespace Xpense.Extension.Core.Entities
{
    public class ExpenseCategory
    {
        public ExpenseCategory()
        {
            Expenses = new HashSet<Expense>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
