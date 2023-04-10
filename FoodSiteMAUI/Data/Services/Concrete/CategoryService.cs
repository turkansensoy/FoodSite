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
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }
        public Task<Category> Add(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Categories");
            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Category>>(stringContent);
        }
    }
}
