using Xpense.Extension.Core.Entities;

namespace Xpense.Extension.Core.Services
{
    public interface IExpenseCategoryService
    {
        ValueTask<List<ExpenseCategory>> GetAsync();
        ValueTask<ExpenseCategory> GetAsync(long id);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<ExpenseCategory> GetAsync(string name);
        ValueTask<bool> AddAsync(ExpenseCategory expenseCategory);
        ValueTask<bool> UpdateAsync(ExpenseCategory expenseCategory);
    }
}
