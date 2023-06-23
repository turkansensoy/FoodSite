using Entities.Concrete;
using Entities.Dtos;
using Entities.Enums;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MudBlazor.Icons;

namespace FoodSiteMAUI.Pages
{
    public partial class RecipeMaterialForm
    {
        private MudTextField<string> multilineReference;
        MudForm form;
        RecipeMaterialAddDto model = new RecipeMaterialAddDto();
        private List<BreadcrumbItem> _items = new List<BreadcrumbItem>
        {
            new BreadcrumbItem("Home", href: "/admin", icon: Icons.Material.Filled.Home),
            new BreadcrumbItem("Taslak Tariflerim", href: "/senderRecipe", icon: Icons.Material.Filled.VideoLibrary),
            new BreadcrumbItem("Yeni Tarif", href: null, disabled: true, icon: Icons.Material.Filled.Create)
        };
        private string _imageBase64Data;
        private string _userAvatar = "images/cooking.png";

        MultiSelectMaterialDto multiSelectMaterial = new MultiSelectMaterialDto();
        List<MultiSelectMaterialDto> ListMultiSelectMaterial = new();

        private List<Category> categorynameselect;
        private List<MaterialDto> materialDtoSelect;
        List<string> listmaterialDtoSelect = new();
        protected override async Task OnInitializedAsync()
        {
            categorynameselect = await _categoryService.GetAll();
            materialDtoSelect = await _materialService.GetAll();
            if (materialDtoSelect != null)
            {
                foreach (var item in materialDtoSelect)
                {
                    listmaterialDtoSelect.Add(item.MaterialName);
                }
            }
        }
        //input select Enum
        public string GetDisplayText(Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Type type = value.GetType();
            if (Attribute.IsDefined(type, typeof(FlagsAttribute)))
            {
                var sb = new System.Text.StringBuilder();

                foreach (Enum field in Enum.GetValues(type))
                {
                    if (Convert.ToInt64(field) == 0 && Convert.ToInt32(value) > 0)
                        continue;

                    if (value.HasFlag(field))
                    {
                        if (sb.Length > 0)
                            sb.Append(", ");

                        var f = type.GetField(field.ToString());
                        var da = (DisplayAttribute)Attribute.GetCustomAttribute(f, typeof(DisplayAttribute));
                        sb.Append(da?.ShortName ?? da?.Name ?? field.ToString());
                    }
                }

                return sb.ToString();
            }
            else
            {
                var f = type.GetField(value.ToString());
                if (f != null)
                {
                    var da = (DisplayAttribute)Attribute.GetCustomAttribute(f, typeof(DisplayAttribute));
                    if (da != null)
                        return da.ShortName ?? da.Name;
                }
            }

            return value.ToString();
        }
        async Task<IEnumerable<string>> Search1(String value)
        {
            await Task.Delay(5);
            if (string.IsNullOrEmpty(value))
                return new string[0];
            return listmaterialDtoSelect.Where(_ => _.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
        private async Task AddMaterial()
        {
            var response = await _materialService.GetByMaterialName(multiSelectMaterial.MaterialName);
            multiSelectMaterial.MaterialId = response.Id;
            MultiSelectMaterialDto addItem = new()
            {
                MaterialName = multiSelectMaterial.MaterialName,
                MaterialId = multiSelectMaterial.MaterialId,
                Guantity = multiSelectMaterial.Guantity,
                MaterialNumber = multiSelectMaterial.MaterialNumber
            };

            ListMultiSelectMaterial.Add(addItem);
            multiSelectMaterial = new() { MaterialNumber = 0, MaterialName = "" };

        }
        private void DeleteItemMaterial(int id)
        {
            var result = ListMultiSelectMaterial.Find(_ => _.MaterialId == id);
            ListMultiSelectMaterial.Remove(result);
        }
        private async Task Submit()
        {
            if (!string.IsNullOrWhiteSpace(_imageBase64Data))
            {
                model.Image = _imageBase64Data;
            }
            if (model.Image == null)
            {
                Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
                Snackbar.Add("Resim ekleyiniz.", Severity.Error);
            }
            else
            {
                RecipeMaterialAddDto recipeMaterialAdd = new()
                {
                    RecipeName = model.RecipeName,
                    RecipeContent = model.RecipeContent,
                    Image = model.Image,
                    NumberofPerson = model.NumberofPerson,
                    PreparationTime = model.PreparationTime,
                    CookingTime = model.CookingTime,
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    RecipeDateTime = DateTime.Now,
                    IsConfirm = false,
                    IsSend = false,
                    CategoryId = model.CategoryId
                };

                recipeMaterialAdd.recipeMaterialDtos = new List<RecipeMaterialDto>();
                foreach (var item in ListMultiSelectMaterial)
                {
                    RecipeMaterialDto recipeMaterial = new()
                    {
                        MaterialId = item.MaterialId,
                        Guantity = item.Guantity,
                        MaterialNumber = item.MaterialNumber
                    };
                    recipeMaterialAdd.recipeMaterialDtos.Add(recipeMaterial);
                }

                await _recipeService.Add(recipeMaterialAdd);
                NavigatonManager.NavigateTo("/senderRecipe", forceLoad: true);
            }
            
        }
        private async void DisplayAction()
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();
            if (photo != null)
            {
                byte[] imageBytes;
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                var stream = await photo.OpenReadAsync();
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    imageBytes = ms.ToArray();
                }
                _imageBase64Data = Convert.ToBase64String(imageBytes);
                _userAvatar = string.Format("data:image/png;base64,{0}", _imageBase64Data);
                this.StateHasChanged();
            }
        }

    }
}
