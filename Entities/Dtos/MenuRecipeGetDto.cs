namespace Entities.Dtos
{
    public class MenuRecipeGetDto
    {
        public int MenuId { get; set; }
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
    }
}
