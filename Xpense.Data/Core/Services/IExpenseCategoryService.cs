using Xpense.Data.Core.Entities;

namespace Xpense.Data.Core.Services
{
    public interface IExpenseCategoryService
    {
        ValueTask<List<ExpenseCategory>> GetAsync();
        ValueTask<ExpenseCategory> GetAsync(long id);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<ExpenseCategory> GetAsync(string name);
        ValueTask<ExpenseCategory> AddAsync(ExpenseCategory expenseCategory);
        ValueTask<bool> UpdateAsync(ExpenseCategory expenseCategory);
    }
}
