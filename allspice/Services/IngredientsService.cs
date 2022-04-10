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

    // internal List<Ingredient> Get()
    // {
    //   return _ingredientsRepo.Get();
    // }

    // Get all ingredients by recipe Id
    internal List<Ingredient> GetAll(int id)
    {
      return _ingredientsRepo.GetAll(id);

    }

    // Create Ingredient on Recipe
    internal Ingredient Create(Ingredient ingredientData, Account userInfo)
    {
      Recipe recipe = _recipesService.GetById(ingredientData.RecipeId);
      ingredientData.RecipeId = recipe.Id;
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("Not your recipe bruv");
      }
      return _ingredientsRepo.Create(ingredientData);
    }

    // Edit Ingredient
    internal Ingredient Update(Ingredient ingredientData, Account userInfo)
    {
      Ingredient original = _ingredientsRepo.GetById(ingredientData.Id);
      Recipe recipe = _recipesService.GetById(original.RecipeId);
      ingredientData.RecipeId = recipe.Id;
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("Not your recipe to edit");
      }

      original.Name = ingredientData.Name ?? original.Name;
      original.Quantity = ingredientData.Quantity ?? original.Quantity;
      original.RecipeId = original.RecipeId;
      _ingredientsRepo.Update(original);
      return original;
    }

    private Ingredient GetById(int id)
    {
      throw new NotImplementedException();
    }

    // Delete Ingredient
    internal object Remove(Account userInfo, int id)
    {
      Ingredient ingredient = _ingredientsRepo.GetById(id);
      Recipe recipe = _recipesService.GetById(ingredient.RecipeId);
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("Not your recipe to delete");
      }
      return _ingredientsRepo.Remove(id);
    }

  }
}