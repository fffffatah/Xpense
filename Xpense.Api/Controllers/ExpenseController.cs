using Microsoft.AspNetCore.Mvc;
using Xpense.Api.Mappers;
using Xpense.Api.Models;
using Xpense.Data.Core.Entities;
using Xpense.Data.Core.Services;

namespace Xpense.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpenseController : ControllerBase
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

    [Route("get/expense")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var expenses = await _expenseService.GetAsync();
        
        var expensesView = XpenseModelMapper.CustomMapper.Mapper.Map<List<ExpenseViewModel>>(expenses);

        return Ok(expensesView);
    }

    [Route("get/expense/{id}")]
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var expense = await _expenseService.GetAsync(id);
        
        var expenseView = XpenseModelMapper.CustomMapper.Mapper.Map<ExpenseViewModel>(expense);

        return Ok(expenseView);
    }

    [Route("add/expense")]
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] ExpenseAddModel expenseAddModel)
    {
        try
        {
            var expense = XpenseModelMapper.CustomMapper.Mapper.Map<Expense>(expenseAddModel);
        
            expense.ExpenseCategory = await _expenseCategoryService.GetAsync(expenseAddModel.Category);

            var responseExpense = await _expenseService.AddAsync(expense);

            return Ok(responseExpense);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Route("edit/expense")]
    [HttpPut]
    public async Task<IActionResult> Edit([FromForm] ExpenseEditModel expenseEditModel)
    {
        try
        {
            var expense = await _expenseService.GetAsync(expenseEditModel.Id);

            var categories = await _expenseCategoryService.GetAsync();
        
            expense.Amount = expenseEditModel.Amount;
            expense.SpentAt = expenseEditModel.SpentAt;
            expense.ExpenseCategory = categories.Find(x => x.Name == expenseEditModel.Category);
        
            var responseExpense = await _expenseService.UpdateAsync(expense);

            return Ok(responseExpense);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Route("delete/expense/{id}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _expenseService.DeleteAsync(id);

        if (isDeleted)
            return Ok("Deleted");

        return BadRequest();
    }
}