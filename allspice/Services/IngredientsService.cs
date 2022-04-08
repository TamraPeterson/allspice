using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _ingredientsRepo;
    private readonly RecipesService _recipesService;
    public IngredientsService(IngredientsRepository ingredientsRepo, RecipesService recipesService)
    {
      _ingredientsRepo = ingredientsRepo;
      _recipesService = recipesService;
    }

    internal List<Ingredient> Get()
    {
      return _ingredientsRepo.Get();
    }

    // Get all ingredients by recipe Id
    internal Ingredient GetAll(int recipeId)
    {
      Ingredient found = _ingredientsRepo.Get(recipeId);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    // Create Ingredient on Recipe
    internal Ingredient Create(Ingredient ingredientData, string userId)
    {
      Recipe recipe = _recipesService.Get(ingredientData.RecipeId);
      if (recipe.CreatorId != userId)
      {
        throw new Exception("Not your recipe bruv");
      }
      return _ingredientsRepo.Create(ingredientData);
    }

    // Edit Ingredient
    internal Ingredient Update(Ingredient ingredientData)
    {
      Ingredient original = GetById(ingredientData.Id);
      original.Name = ingredientData.Name ?? original.Name;
      original.Quantity = ingredientData.Quantity ?? original.Quantity;
      _ingredientsRepo.Update(original);
      return original;
    }

    private Ingredient GetById(int id)
    {
      throw new NotImplementedException();
    }

    // Delete Ingredient
    internal void Remove(int id)
    {
      GetById(id);
      _ingredientsRepo.Remove(id);
    }
  }
}