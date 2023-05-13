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
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Category> Add(Category category)
        {
            var response = await _httpClient.PostAsync("api/Categories", new StringContent(
                JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Category>();
        }
        public async void Delete(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"api/Categories/{id}");
            responseMessage.EnsureSuccessStatusCode();
        }

        public async Task<List<Category>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Categories");
            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Category>>(stringContent);
        }

        public async Task<Category> Update(Category category)
        {
           var responseMessage= await _httpClient.PutAsJsonAsync("api/Categories", category);
            responseMessage.EnsureSuccessStatusCode();
           return await responseMessage.Content.ReadFromJsonAsync<Category>();
        }
    }
}
