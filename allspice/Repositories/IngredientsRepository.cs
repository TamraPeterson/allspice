using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal List<Ingredient> Get()
    {
      string sql = @"
            SELECT i.*, r.*
            FROM ingredients i
            JOIN recipes r WHERE r.id = i.RecipeId;
            ";
      return _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
      {
        ingredient.RecipeId = recipe.Id;
        return ingredient;
      }).ToList();
    }

    internal Ingredient Get(int id)
    {
      throw new NotImplementedException();
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      throw new NotImplementedException();
    }

    internal void Update(Ingredient original)
    {
      throw new NotImplementedException();
    }

    internal void Remove(int id)
    {
      throw new NotImplementedException();
    }
  }
}