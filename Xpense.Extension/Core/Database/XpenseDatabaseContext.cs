using Microsoft.EntityFrameworkCore;
using Xpense.Extension.Core.Entities;

namespace Xpense.Extension.Core.Database
{
    public class XpenseDatabaseContext : DbContext
    {
        public XpenseDatabaseContext(DbContextOptions<XpenseDatabaseContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpensesCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Expense>(e =>
            {
                e.HasOne(category => category.ExpenseCategory)
                    .WithMany(expense => expense.Expenses)
                    .HasForeignKey(category => category.ExpenseCategoryId)
                    .HasConstraintName("expenseCategories_expenses_FK");
            });

            builder.Entity<ExpenseCategory>(e =>
            {
                e.HasIndex(e => e.Name)
                    .IsUnique(true);

                e.HasMany(e => e.Expenses)
                    .WithOne(x => x.ExpenseCategory)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
