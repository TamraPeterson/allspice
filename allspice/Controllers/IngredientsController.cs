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
  [Route("api/[controller]")]
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
        Ingredient ingredient = _ingredientsService.Create(ingredientData, userInfo);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // TODO edit only works when user enters recipe id as part of the edit, otherwise it isn't able to get recipe by id to make the change in the service.
    // Edit Ingredient 
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Update([FromBody] Ingredient ingredientData, int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        ingredientData.Id = id;
        Ingredient ingredient = _ingredientsService.Update(ingredientData, userInfo);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // Delete ingredient
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_ingredientsService.Remove(userInfo, id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }








  }
}