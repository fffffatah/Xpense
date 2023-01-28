using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Xpense.Extension.Core.Entities;
using Xpense.Extension.Core.Services;
using Xpense.Models;
using static Xpense.Mappers.XpenseModelMapper;

namespace Xpense.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenseController(
            ILogger<ExpenseController> logger,
            IExpenseService expenseService,
            IExpenseCategoryService expenseCategoryService)
        {
            _logger = logger;
            _expenseService = expenseService;
            _expenseCategoryService = expenseCategoryService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Index()
        {
            var expenses = await _expenseService.GetAsync();

            var expensesView = CustomMapper.Mapper.Map<List<ExpenseViewModel>>(expenses);

            return View(expensesView);
        }

        [HttpGet]
        public async ValueTask<IActionResult> Add()
        {
            var categories = await _expenseCategoryService.GetAsync();

            /* Convert List<ExpenseCategory> to List<SelectListItm> for the drop down */
            ViewBag.ExpenseCategories = categories.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name
            });

            return View();
        }

        [HttpPost]
        public async ValueTask<IActionResult> Add(ExpenseAddModel expenseAddModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _expenseCategoryService.GetAsync();

                ViewBag.ExpenseCategories = categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name
                });

                return View();
            }

            var expense = CustomMapper.Mapper.Map<Expense>(expenseAddModel);

            await _expenseService.AddAsync(expense);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async ValueTask<IActionResult> Delete(long id)
        {
            await _expenseService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
