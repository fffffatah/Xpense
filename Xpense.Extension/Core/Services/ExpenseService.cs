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


    }
}
