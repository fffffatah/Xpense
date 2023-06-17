using Xpense.Extension.Core.Entities;
using Xpense.Extension.Core.Repository;

namespace Xpense.Extension.Core.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IRepository<ExpenseCategory> _expenseCategoryRepository;

        public ExpenseCategoryService(IRepository<ExpenseCategory> expenseCategoryService)
        {
            _expenseCategoryRepository = expenseCategoryService;
        }

        public async ValueTask<List<ExpenseCategory>> GetAsync()
        {
            return await _expenseCategoryRepository.GetAsync();
        }

        public async ValueTask<ExpenseCategory> GetAsync(long id)
        {
            return await _expenseCategoryRepository.GetAsync(id);
        }

        public async ValueTask<ExpenseCategory> GetAsync(string name)
        {
            var data = await _expenseCategoryRepository.FindAsync(x => x.Name == name);

            return data.FirstOrDefault();
        }

        public async ValueTask<bool> DeleteAsync(long id)
        {
            var expenseCategory = await _expenseCategoryRepository.GetAsync(id);

            var data = await _expenseCategoryRepository.DeleteAsync(expenseCategory);

            return data != null;
        }

        public async ValueTask<ExpenseCategory> AddAsync(ExpenseCategory expenseCategory)
        {
            var data = await _expenseCategoryRepository.AddAsync(expenseCategory);

            return data;
        }

        public async ValueTask<bool> UpdateAsync(ExpenseCategory expenseCategory)
        {
            var data = await _expenseCategoryRepository.UpdateAsync(expenseCategory);

            return data != null;
        }
    }
}
