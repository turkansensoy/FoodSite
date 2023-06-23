using Entities.Concrete;
using Entities.Dtos;
using FoodSiteMAUI.Data.Services.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FoodSiteMAUI.Data.Services.Concrete
{
    public class MenuService : IMenuService
    {
        private readonly HttpClient _httpClient;
        public MenuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Menu> Add(RecipeMenuDto recipeMenuDto)
        {
            var response=await _httpClient.PostAsync("api/Menus", new StringContent(
                JsonConvert.SerializeObject(recipeMenuDto), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Menu>();
        }

        public async Task<List<GetRecipeMenuDto>> GetAllMenuRecipe()
        {
            var response = await _httpClient.GetAsync("api/Menus");
            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<GetRecipeMenuDto>>(stringContent);
        }
        public async Task<List<GetRecipeMenuDto>> GetById(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"api/Menus/{id}");
            responseMessage.EnsureSuccessStatusCode();

            var stringContent = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<GetRecipeMenuDto>>(stringContent);
        }
    }
}
