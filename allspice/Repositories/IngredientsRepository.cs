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
      string sql = @"
      INSERT INTO
      ingredients (name, quantity, recipeId)
      VALUES
      (@Name, @Quantity, @RecipeId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }

    internal void Update(Ingredient original)
    {
      throw new NotImplementedException();
    }

    internal string Remove(int id)
    {
      string sql = @"
        DELETE FROM ingredients WHERE id = @id LIMIT 1;
      ";
      int rowsAffected = _db.Execute(sql, new { id });
      if (rowsAffected > 0)
      {
        return "delorted";
      }
      throw new Exception("could not delete");
    }
  }
}