using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class StepsService
  {
    private readonly StepsRepository _sr;
    private readonly RecipesService _rs;
    public StepsService(StepsRepository sr, RecipesService rs)
    {
      _sr = sr;
      _rs = rs;
    }

    internal Step Create(Step stepData, Account userInfo)
    {
      Recipe recipe = _rs.GetById(stepData.RecipeId);
      stepData.RecipeId = recipe.Id;
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("Not your recipe bruv");
      }
      return _sr.Create(stepData);
    }

    internal Step Update(Step stepData, Account userInfo)
    {
      Step original = _sr.GetById(stepData.Id);
      Recipe recipe = _rs.GetById(original.RecipeId);
      stepData.RecipeId = recipe.Id;
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("not your recipe");
      }
      original.Position = stepData.Position;
      original.Body = stepData.Body ?? original.Body;
      original.RecipeId = original.RecipeId;
      _sr.Update(original);
      return original;
    }

    internal object Remove(Account userInfo, int id)
    {
      Step step = _sr.GetById(id);
      Recipe recipe = _rs.GetById(step.RecipeId);
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("Not your recipe to mess with");
      }
      return _sr.Remove(id);
    }

    internal List<Step> GetAll(int id)
    {
      return _sr.GetAll(id);
    }
  }
}