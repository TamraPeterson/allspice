using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _ingredientsRepo;
    public IngredientsService(IngredientsRepository ingredientsRepo)
    {
      _ingredientsRepo = ingredientsRepo;
    }

    internal List<Ingredient> Get()
    {
      return _ingredientsRepo.Get();
    }

    internal Ingredient Get(int id)
    {
      Ingredient found = _ingredientsRepo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      return _ingredientsRepo.Create(ingredientData);
    }
    internal Ingredient Update(Ingredient ingredientData)
    {
      Ingredient original = Get(ingredientData.Id);
      original.Name = ingredientData.Name ?? original.Name;
      original.Quantity = ingredientData.Quantity ?? original.Quantity;
      _ingredientsRepo.Update(original);
      return original;
    }

    internal void Remove(int id)
    {
      Get(id);
      _ingredientsRepo.Remove(id);
    }
  }
}