namespace allspice.Models
{
  public class Ingredient
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Quantity { get; set; }
    public int recipeId { get; set; }
  }
}