namespace Entities.Dtos
{
	public class ComfirmRecipeDto
    {
		public int Id { get; set; }
		public string RecipeName { get; set; }
		public string RecipeContent { get; set; }
		public string Image { get; set; }
		public int NumberofPerson { get; set; }
		public int PreparationTime { get; set; }
		public int CookingTime { get; set; }
		public string UserName { get; set; }
		public string UserEmail { get; set; }
		public DateTime RecipeDateTime { get; set; }
		public bool IsConfirm { get; set; } = false;
		public bool IsSend { get; set; } = false;
        public bool IsTurnBack { get; set; } = false;
        public int CategoryId { get; set; }
		public bool ShowDetails { get; set; }
		public List<MultiSelectMaterialDto> recipeMaterialDtos { get; set; }
	}
}
