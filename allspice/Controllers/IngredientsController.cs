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


    // [HtttpGet("{id}")]
    // public ActionResult<List<Ingredient>> GetById(int id)


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
    [Authorize]
    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _ingredientsService.Remove(userInfo, id);
        return Ok("Delorted ");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }








  }
}