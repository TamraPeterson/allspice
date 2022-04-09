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



    // Get all ingredients by recipeId
    internal List<Ingredient> GetAll(int id)
    {
      string sql = @"
            SELECT * FROM ingredients i
            WHERE i.recipeId = @id;";
      return _db.Query<Ingredient>(sql, new { id }).ToList();
    }


    // Create Ingredient
    internal Ingredient Create(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO
      ingredients (name, quantity, recipeId)
      VALUES
      (@Name, @Quantity, @RecipeId);";
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }


    // Edit Ingredient
    internal void Update(Ingredient original)
    {
      throw new NotImplementedException();
    }


    // Delete Ingredient
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