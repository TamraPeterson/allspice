using System;
using System.Collections.Generic;
using allspice.Services;
using allspice.Models;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _rs;
    private readonly IngredientsService _ingredientsService;

    public RecipesController(RecipesService rs)
    {
      _rs = rs;
    }


    //Get All Recipes
    [HttpGet]
    public ActionResult<List<Recipe>> Get()
    {
      try
      {
        List<Recipe> recipes = _rs.Get();
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Get Recipe by Id
    [HttpGet("{id}")]
    public ActionResult<Recipe> Get(int id)
    {
      try
      {
        Recipe recipe = _rs.Get(id);
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

    //Delete Recipe
    [HttpDelete("{id}")]
    public ActionResult<String> Remove(int id)
    {
      try
      {
        _rs.Remove(id);
        return Ok("Delorted ");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // SECTION Ingredients

    //Get ingredients by recipe id
    [HttpGet("{id}/ingredients")]
    public ActionResult<Ingredient> GetIngredientsByRecipeId(int id)
    {
      try
      {
        Ingredient ingredient = _ingredientsService.GetAll(id);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //Edit ingredients by recipe id
    [HttpPut("{id}/ingredients")]
    public ActionResult<Recipe> UpdateIngredientsByRecipeId(int id, [FromBody] Recipe recipeData)
    {
      try
      {
        recipeData.Id = id;
        Recipe recipe = _rs.Update(recipeData);
        return Ok(recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Create Ingredient on Recipe
    [HttpPost("{id}/ingredients")]
    public ActionResult<Ingredient> Create([FromBody] Ingredient ingredientData, int)
    {
      try
      {
        Ingredient ingredient = _ingredientsService.Create(ingredientData);
        return Created($"api/{id}/{ingredient.Id}", ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // SECTION Steps


  }
}