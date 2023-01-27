using Xpense.Extension.Core.Entities;
using Xpense.Extension.Core.Repository;

namespace Xpense.Extension.Core.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IRepository<ExpenseCategory> _expenseCategoryService;

        public ExpenseCategoryService(IRepository<ExpenseCategory> expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
        }

        public async ValueTask<List<ExpenseCategory>> GetAsync()
        {
            return await _expenseCategoryService.GetAsync();
        }

        public async ValueTask<ExpenseCategory> GetAsync(long id)
        {
            return await _expenseCategoryService.GetAsync(id);
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var expenseCategory = await _expenseCategoryService.GetAsync(id);

            var data = await _expenseCategoryService.DeleteAsync(expenseCategory);

            return data != null;
        }

        public async ValueTask<bool> AddAsync(ExpenseCategory expenseCategory)
        {
            var data = await _expenseCategoryService.AddAsync(expenseCategory);

            return data != null;
        }

        public async ValueTask<bool> UpdateAsync(ExpenseCategory expenseCategory)
        {
            var data = await _expenseCategoryService.UpdateAsync(expenseCategory);

            return data != null;
        }
    }
}
