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

    internal List<Recipe> Get()
    {
      return _recipesRepo.Get();
    }

    // TODO change names of these functions
    internal Recipe Get(int id)
    {
      Recipe found = _recipesRepo.Get(id);
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

    internal Recipe Update(Recipe recipeData)
    {
      Recipe original = Get(recipeData.Id);
      original.Title = recipeData.Title ?? original.Title;
      original.Subtitle = recipeData.Subtitle ?? original.Subtitle;
      original.Category = recipeData.Category ?? original.Category;
      original.Image = recipeData.Image ?? original.Image;
      _recipesRepo.Update(original);
      return original;
    }

    internal void Remove(int id)
    {
      Get(id);
      _recipesRepo.Remove(id);
    }
  }
}