using Xpense.Extension.Core.Entities;

namespace Xpense.Extension.Core.Services
{
    public interface IExpenseService
    {
        ValueTask<List<Expense>> GetAsync();
        ValueTask<Expense> GetAsync(long id);
        ValueTask<List<Expense>> GetBetweenDates(DateTime startDate, DateTime endDate);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<bool> AddAsync(Expense expense);
        ValueTask<bool> UpdateAsync(Expense expense);
    }
}
