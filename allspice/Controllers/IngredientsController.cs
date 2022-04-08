using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Services;
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

    [HttpGet]
    public ActionResult<List<Ingredient>> Get()
    {
      try
      {
        List<Ingredient> ingredients = _ingredientsService.Get();
        return Ok(ingredients);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Ingredient> Get(int id)
    {
      try
      {
        Ingredient ingredient = _ingredientsService.Get(id);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Ingredient> Create([FromBody] Ingredient ingredientData)
    {
      try
      {
        Ingredient ingredient = _ingredientsService.Create(ingredientData);
        return Created($"api/ingredients/{ingredient.Id}", ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

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