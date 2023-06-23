namespace Entities.Dtos
{
    public class RecipeMenuDto
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public List<RecipeIdMenuDto> Recipes { get; set; }

    }
}
