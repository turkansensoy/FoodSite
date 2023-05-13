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
    public class MaterialService : IMaterialService
    {
        private readonly HttpClient _httpClient;
        public MaterialService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<MaterialDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("api/Materials");
            response.EnsureSuccessStatusCode();
            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<MaterialDto>>(stringContent);
        }

        public async Task<Material> GetByMaterialName(string materialName)
        {
          var response= await _httpClient.GetAsync($"api/Materials/{materialName}");
            response.EnsureSuccessStatusCode();
           return await response.Content.ReadFromJsonAsync<Material>();
        }

        public async Task<List<MultiSelectMaterialDto>> GetMultiSelectMaterial(int id)
        {
          var response= await _httpClient.GetAsync($"api/Materials/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<MultiSelectMaterialDto>>();
        }
    }
}
