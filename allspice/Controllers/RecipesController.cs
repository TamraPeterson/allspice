using System;
using System.Collections.Generic;
using allspice.Services;
using allspice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;

namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _rs;
    private readonly IngredientsService _ingredientsService;

    public RecipesController(RecipesService rs, IngredientsService ingredientsService)
    {
      _ingredientsService = ingredientsService;
      _rs = rs;
    }


    //Get All Recipes
    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
      try
      {
        List<Recipe> recipes = _rs.GetAll();
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Get Recipe by Id
    [HttpGet("{id}")]
    public ActionResult<Recipe> GetById(int id)
    {
      try
      {
        Recipe recipe = _rs.GetById(id);
        return Ok(recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Create Recipe
    [HttpPost]
    public ActionResult<Recipe> Create([FromBody] Recipe recipeData)
    {
      try
      {
        Recipe recipe = _rs.Create(recipeData);
        return Created($"api/recipes/{recipe.Id}", recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Edit recipe
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> Update([FromBody] Recipe recipeData, int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.Id = id;
        Recipe recipe = _rs.Update(recipeData, userInfo);
        return Ok(recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Delete Recipe
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _rs.Remove(id, userInfo);
        return Ok("delorted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // SECTION Ingredients

    //Get ingredients by recipe id
    [HttpGet("{id}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int id)
    {
      try
      {
        List<Ingredient> ingredients = _ingredientsService.GetAll(id);
        return Ok(ingredients);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // Create Ingredient on Recipe
    // [HttpPost("{id}/ingredients")]
    // [Authorize]
    // public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData, string Id)
    // {
    //   try
    //   {
    //     Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
    //     Ingredient ingredient = _ingredientsService.Create(ingredientData, userInfo.Id);
    //     return Ok(ingredient);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    // SECTION Steps


  }
}