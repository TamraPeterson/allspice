namespace allspice.Models
{
  public class Step
  {
    public int Id { get; set; }
    public int Number { get; set; }
    public string Body { get; set; }
    public int RecipeId { get; set; }

    public Recipe? Recipe { get; set; }
  }
}