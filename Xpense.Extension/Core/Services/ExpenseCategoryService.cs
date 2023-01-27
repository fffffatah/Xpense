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


    }
}
