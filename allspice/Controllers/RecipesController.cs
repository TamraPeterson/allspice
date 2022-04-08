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
    public RecipesController(RecipesService rs)
    {
      _rs = rs;
    }

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

    [HttpPut("{id}")]
    public ActionResult<Recipe> Update(int id, [FromBody] Recipe recipeData)
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




  }
}