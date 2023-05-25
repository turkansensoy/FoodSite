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
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Recipe> Add(RecipeMaterialAddDto recipeMaterialAddDto)
        {
            var response = await _httpClient.PostAsync("api/Recipes", new StringContent(
             JsonConvert.SerializeObject(recipeMaterialAddDto), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Recipe>();
        }

        public async void Delete(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"api/Recipes/{id}");
            responseMessage.EnsureSuccessStatusCode(); 
        }

        public async Task<List<RecipeDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Recipes");
            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<RecipeDto>>(stringContent);
        }

        public async Task<List<RecipeEngineDto>> GetAllRecipeEngine()
        {
           var  httpResponse= await _httpClient.GetAsync("api/Recipes/listWhatToDo");
            httpResponse.EnsureSuccessStatusCode();
            var  stringContent= await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<RecipeEngineDto>>(stringContent);
        }

        public async Task<Recipe> GetById(int id)
        {
            var response= await _httpClient.GetAsync($"api/Recipes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Recipe>();
        }

        public async Task<List<RecipeDto>> GetRecipeByCategoryId(int categoryId)
        {
         var  response= await _httpClient.GetAsync($"api/Recipes/getRecipeByCategoryId/{categoryId}");
            response.EnsureSuccessStatusCode();
           return await response.Content.ReadFromJsonAsync<List<RecipeDto>>();
        }

        public async Task<List<RecipeEngineDto>> GetRecipeEngineDtos(int materialId)
        {
            var response= await _httpClient.GetAsync($"api/Recipes/getRecipeEngine/{materialId}");
            response.EnsureSuccessStatusCode();
           return await response.Content.ReadFromJsonAsync<List<RecipeEngineDto>>();
        }

        public async Task<RecipeDto> Update(RecipeDto recipes)
        {
          var responseMessage = await  _httpClient.PutAsJsonAsync("api/Recipes", recipes);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadFromJsonAsync<RecipeDto>();
        }
    }
}
