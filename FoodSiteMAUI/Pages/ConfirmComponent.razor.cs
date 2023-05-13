using Entities.Concrete;
using Entities.Dtos;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSiteMAUI.Pages
{
    public partial class ConfirmComponent
    {
        private List<BreadcrumbItem> _items = new List<BreadcrumbItem>
    {
        new BreadcrumbItem("Home", href: "#", icon: Icons.Material.Filled.Home),
        new BreadcrumbItem("Videos", href: "#", icon: Icons.Material.Filled.VideoLibrary),
        new BreadcrumbItem("Create", href: null, disabled: true, icon: Icons.Material.Filled.Create)
    };

        private static List<ComfirmRecipeDto> ConfirmRecipeDto;
        private MudTextField<string> multilineReference;
        private List<Category> categorynameselect;
        protected async override void OnInitialized()
        {
            categorynameselect = await _categoryService.GetAll();
            FillConfirmRecipeDto();
        }

        private async void FillConfirmRecipeDto()
        {
            List<ComfirmRecipeDto> AddComfirmRecipeDto = new List<ComfirmRecipeDto>();
            var result = await _recipeService.GetAll();
            foreach (var item in result)
            {
                ComfirmRecipeDto comfirmRecipe = new ComfirmRecipeDto()
                {
                    Id = item.Id,
                    RecipeName = item.RecipeName,
                    RecipeContent = item.RecipeContent,
                    Image = item.Image,
                    NumberofPerson = item.NumberofPerson,
                    PreparationTime = item.PreparationTime,
                    CookingTime = item.CookingTime,
                    UserName = item.UserName,
                    UserEmail = item.UserEmail,
                    RecipeDateTime = item.RecipeDateTime,
                    IsConfirm = item.IsConfirm,
                    IsSend = item.IsSend,
                    IsTurnBack = item.IsTurnBack,
                    CategoryId = item.CategoryId,
                    ShowDetails = false
                };
                var list = await _materialService.GetMultiSelectMaterial(Convert.ToInt32(item.Id));
                comfirmRecipe.recipeMaterialDtos = new List<MultiSelectMaterialDto>();
                foreach (var item1 in list)
                {
                    MultiSelectMaterialDto recipeMaterial = new()
                    {
                        id = item1.id,
                        MaterialId = item1.MaterialId,
                        Guantity = item1.Guantity,
                        MaterialName = item1.MaterialName,
                        MaterialNumber = item1.MaterialNumber
                    };
                    comfirmRecipe.recipeMaterialDtos.Add(recipeMaterial);
                }
                if (comfirmRecipe.IsConfirm == false && comfirmRecipe.IsSend == true && comfirmRecipe.IsTurnBack == false)
                {
                    AddComfirmRecipeDto.Add(comfirmRecipe);
                    ConfirmRecipeDto = AddComfirmRecipeDto;
                    
                }
            }
            //this.StateHasChanged();
        }

        private void ShowBtnPress(int nr)
        {
            ComfirmRecipeDto tmpPerson = ConfirmRecipeDto.First(f => f.Id == nr);
            tmpPerson.ShowDetails = !tmpPerson.ShowDetails;
        }

        private async void Submit(int id)
        {
            Recipe recipeItem = await _recipeService.GetById(id);
            var list = await _materialService.GetMultiSelectMaterial(id);
            RecipeDto recipeAdd = new()
            {
                Id = recipeItem.Id,
                RecipeName = recipeItem.RecipeName,
                RecipeContent = recipeItem.RecipeContent,
                Image = recipeItem.Image,
                NumberofPerson = recipeItem.NumberofPerson,
                PreparationTime = recipeItem.PreparationTime,
                CookingTime = recipeItem.CookingTime,
                UserName = recipeItem.UserName,
                UserEmail = recipeItem.UserEmail,
                RecipeDateTime = DateTime.Now,
                IsConfirm = true,
                IsSend = true,
                IsTurnBack = false,
                CategoryId = recipeItem.CategoryId
            };
            recipeAdd.recipeMaterialDtos = new List<RecipeMaterialDto>();
            foreach (var item in list)
            {
                RecipeMaterialDto recipeMaterial = new()
                {
                    Id = item.id,
                    MaterialId = item.MaterialId,
                    Guantity = item.Guantity,
                    MaterialNumber = item.MaterialNumber
                };
                recipeAdd.recipeMaterialDtos.Add(recipeMaterial);
            }
            var result = await _recipeService.Update(recipeAdd);
            var comfirmRecipeDto = ConfirmRecipeDto.Find(_ => _.Id == id);
            ConfirmRecipeDto.Remove(comfirmRecipeDto);
            NavigatonManager.NavigateTo("/confirmComponent", forceLoad: true);
        }
        private async void EditConfirmRecipe(int id)
        {
            Recipe recipeItem = await _recipeService.GetById(id);
            var list = await _materialService.GetMultiSelectMaterial(id);
            RecipeDto recipeAdd = new()
            {
                Id = recipeItem.Id,
                RecipeName = recipeItem.RecipeName,
                RecipeContent = recipeItem.RecipeContent,
                Image = recipeItem.Image,
                NumberofPerson = recipeItem.NumberofPerson,
                PreparationTime = recipeItem.PreparationTime,
                CookingTime = recipeItem.CookingTime,
                UserName = recipeItem.UserName,
                UserEmail = recipeItem.UserEmail,
                RecipeDateTime = DateTime.Now,
                IsConfirm = false,
                IsSend = false,
                IsTurnBack = true,
                CategoryId = recipeItem.CategoryId
            };
            recipeAdd.recipeMaterialDtos = new List<RecipeMaterialDto>();
            foreach (var item in list)
            {
                RecipeMaterialDto recipeMaterial = new()
                {
                    Id = item.id,
                    MaterialId = item.MaterialId,
                    Guantity = item.Guantity,
                    MaterialNumber = item.MaterialNumber
                };
                recipeAdd.recipeMaterialDtos.Add(recipeMaterial);
            }
            var result = await _recipeService.Update(recipeAdd);
            var comfirmRecipeDto = ConfirmRecipeDto.Find(_ => _.Id == id);
            ConfirmRecipeDto.Remove(comfirmRecipeDto);
            NavigatonManager.NavigateTo("/confirmComponent", forceLoad: true);
        }
    }
}
