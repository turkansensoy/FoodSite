namespace Entities.Dtos
{
    public class MenuListGetRecipeMenuDto
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public bool ShowDetails { get; set; }
        public List<MenuRecipeGetDto> MenuRecipeGetDtos { get; set; }
    }
}
