using Xpense.Extension.Core.Entities;
using Xpense.Extension.Core.Repository;

namespace Xpense.Extension.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense> _expenseService;

        public ExpenseService(IRepository<Expense> expenseService)
        {
            _expenseService = expenseService;
        }

        public async ValueTask<List<Expense>> GetAsync()
        {
            return await _expenseService.GetAsync();
        }

        public async ValueTask<Expense> GetAsync(long id)
        {
            return await _expenseService.GetAsync(id);
        }

        public async ValueTask<List<Expense>> GetBetweenDates(DateTime startDate, DateTime endDate)
        {
            var data = await _expenseService.FindAsync(x => x.SpentAt >= startDate && x.SpentAt <= endDate);

            return data.ToList();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var expense = await _expenseService.GetAsync(id);

            var data = await _expenseService.DeleteAsync(expense);

            return data != null;
        }

        public async ValueTask<bool> AddAsync(Expense expense)
        {
            var data = await _expenseService.AddAsync(expense);

            return data != null;
        }

        public async ValueTask<bool> UpdateAsync(Expense expense)
        {
            var data = await _expenseService.UpdateAsync(expense);

            return data != null;
        }
    }
}
