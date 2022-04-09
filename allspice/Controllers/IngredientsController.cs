using System;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
  [ApiController]
  [Route("api/recipes/{recipeId}/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ingredientsService;
    public IngredientsController(IngredientsService ingredientsService)
    {
      _ingredientsService = ingredientsService;
    }


    // Create Ingredient
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Ingredient ingredient = _ingredientsService.Create(ingredientData, userInfo.Id);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Edit Ingredient 
    [HttpPut("{id}")]
    public ActionResult<Ingredient> Update(int id, [FromBody] Ingredient ingredientData)
    {
      try
      {
        ingredientData.Id = id;
        Ingredient ingredient = _ingredientsService.Update(ingredientData);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // Delete ingredient
    [HttpDelete("{id}")]
    public ActionResult<String> Remove(int id)
    {
      try
      {
        _ingredientsService.Remove(id);
        return Ok("Delorted ");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }








  }
}