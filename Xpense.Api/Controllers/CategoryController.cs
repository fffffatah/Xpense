using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Xpense.Api.Helpers;
using Xpense.Api.Mappers;
using Xpense.Api.Models;
using Xpense.Extension.Core.Entities;
using Xpense.Extension.Core.Services;

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
            await _expenseCategoryService.AddAsync(expenseCategory);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

        return Ok();
    }
}