using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Xpense.Data.Core.Entities;
using Xpense.Data.Core.Services;
using Xpense.Models;
using static Xpense.Mappers.XpenseModelMapper;

namespace Xpense.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IExpenseCategoryService _expenseCategoryService;

        public CategoryController(
            ILogger<CategoryController> logger,
            IExpenseCategoryService expenseCategoryService)
        {
            _logger = logger;
            _expenseCategoryService = expenseCategoryService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> Index()
        {
            var expenseCategories = await _expenseCategoryService.GetAsync();

            var expenseCategoriesView = CustomMapper.Mapper.Map<List<ExpenseCategoryViewModel>>(expenseCategories);

            return View(expenseCategoriesView);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async ValueTask<IActionResult> Add(ExpenseCategoryAddModel expenseCategoryAddModel)
        {
            if (!ModelState.IsValid)
                return View();

            var expenseCategory = CustomMapper.Mapper.Map<ExpenseCategory>(expenseCategoryAddModel);

            try
            {
                await _expenseCategoryService.AddAsync(expenseCategory);
            }
            catch (Exception ex)
            {
                if (((SqlException)ex.InnerException).Number == 2601)
                    ModelState.AddModelError("Name", "* A same category already exists!");

                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async ValueTask<IActionResult> Edit(long id)
        {
            var category = await _expenseCategoryService.GetAsync(id);

            var categoryEditModel = CustomMapper.Mapper.Map<ExpenseCategoryEditModel>(category);

            return View(categoryEditModel);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Edit(ExpenseCategoryEditModel expenseCategoryEditModel)
        {
            if (!ModelState.IsValid)
                return View();

            var category = await _expenseCategoryService.GetAsync(expenseCategoryEditModel.Id);

            category.Name = expenseCategoryEditModel.Name;

            await _expenseCategoryService.UpdateAsync(category);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async ValueTask<IActionResult> Delete(long id)
        {
            await _expenseCategoryService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
