using Entities.Concrete;
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
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Recipe> Add(Recipe recipes)
        {
            var response = await _httpClient.PostAsync("api/Recipes", new StringContent(
             JsonConvert.SerializeObject(recipes), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Recipe>();
        }

        public async void Delete(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"api/Recipes/{id}");
            responseMessage.EnsureSuccessStatusCode(); 
        }

        public async Task<List<Recipe>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Recipes");
            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Recipe>>(stringContent);
        }

        public Task<Recipe> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> Update(Recipe recipes)
        {
            throw new NotImplementedException();
        }
    }
}
