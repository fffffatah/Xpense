using Xpense.Data.Core.Entities;
using Xpense.Data.Core.Repository;

namespace Xpense.Data.Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IRepository<Expense> _expenseRepository;

        public ExpenseService(IRepository<Expense> expenseService)
        {
            _expenseRepository = expenseService;
        }

        public async ValueTask<List<Expense>> GetAsync()
        {
            return await _expenseRepository.GetAsync();
        }

        public async ValueTask<Expense> GetAsync(long id)
        {
            return await _expenseRepository.GetAsync(id);
        }

        public async ValueTask<List<Expense>> GetBetweenDates(DateTime startDate, DateTime endDate)
        {
            var data = await _expenseRepository.FindAsync(x => x.SpentAt >= startDate && x.SpentAt <= endDate);

            return data.ToList();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var expense = await _expenseRepository.GetAsync(id);

            var data = await _expenseRepository.DeleteAsync(expense);

            return data != null;
        }

        public async ValueTask<bool> AddAsync(Expense expense)
        {
            var data = await _expenseRepository.AddAsync(expense);

            return data != null;
        }

        public async ValueTask<bool> UpdateAsync(Expense expense)
        {
            var data = await _expenseRepository.UpdateAsync(expense);

            return data != null;
        }
    }
}
