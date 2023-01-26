using Microsoft.EntityFrameworkCore;
using Xpense.Extension.Core.Entities;

namespace Xpense.Extension.Core.Database
{
    public class XpenseDatabaseContext : DbContext
    {
        public XpenseDatabaseContext(DbContextOptions<XpenseDatabaseContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpensesCategories { get; set; }


    }
}
