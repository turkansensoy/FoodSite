namespace Entities.Dtos
{
    public class GetRecipeMenuDto
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public List<MenuRecipeGetDto> MenuRecipeGetDtos { get; set; }
    }
}
