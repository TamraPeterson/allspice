using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _recipesRepo;
    public RecipesService(RecipesRepository recipesRepo)
    {
      _recipesRepo = recipesRepo;
    }

    internal List<Recipe> GetAll()
    {
      return _recipesRepo.GetAll();
    }

    // TODO change names of these functions
    internal Recipe GetById(int id)
    {
      Recipe found = _recipesRepo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Recipe Create(Recipe recipeData)
    {
      return _recipesRepo.Create(recipeData);
    }

    internal Recipe Update(Recipe recipeData, Account userInfo)
    {
      Recipe original = GetById(recipeData.Id);
      if (original.CreatorId != userInfo.Id)
      {
        throw new Exception("Not your recipe");
      }
      original.Title = recipeData.Title ?? original.Title;
      original.Subtitle = recipeData.Subtitle ?? original.Subtitle;
      original.Category = recipeData.Category ?? original.Category;
      original.Image = recipeData.Image ?? original.Image;
      _recipesRepo.Update(original);
      return original;
    }

    internal string Remove(int id, Account userInfo)
    {
      Recipe recipe = _recipesRepo.GetById(id);
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("not your recipe");
      }
      return _recipesRepo.Remove(id);
    }
  }
}