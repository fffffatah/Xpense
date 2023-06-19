using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Xpense.Api.Helpers;
using Xpense.Api.Mappers;
using Xpense.Api.Models;
using Xpense.Data.Core.Entities;
using Xpense.Data.Core.Services;

namespace Xpense.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IExpenseCategoryService _expenseCategoryService;
    
    public CategoryController(ILogger<CategoryController> logger, IExpenseCategoryService expenseCategoryService)
    {
        _logger = logger;
        _expenseCategoryService = expenseCategoryService;
    }

    [Route("add/category")]
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] ExpenseCategoryAddModel expenseCategoryAddModel)
    {
        if (!ValidationHelper.ValidateCategory(expenseCategoryAddModel.Name))
            return BadRequest();

        var expenseCategory = XpenseModelMapper.CustomMapper.Mapper.Map<ExpenseCategory>(expenseCategoryAddModel);
        
        try
        {
            var responseExpenseCategory = await _expenseCategoryService.AddAsync(expenseCategory);
            
            return Ok(responseExpenseCategory);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [Route("get/category")]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var expenseCategories = await _expenseCategoryService.GetAsync();

        var categories = XpenseModelMapper.CustomMapper.Mapper.Map<List<ExpenseCategoryViewModel>>(expenseCategories);

        return Ok(categories);
    }
    
    [Route("get/category/{id}")]
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var expenseCategories = await _expenseCategoryService.GetAsync(id);
            var categories = XpenseModelMapper.CustomMapper.Mapper.Map<ExpenseCategoryViewModel>(expenseCategories);
            
            return Ok(categories);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    
    [Route("delete/category/{id}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _expenseCategoryService.DeleteAsync(id);

        if (isDeleted)
            return Ok();

        return BadRequest();
    }
}