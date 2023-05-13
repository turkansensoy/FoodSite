using FoodSiteMAUI.Data.Services.Abstract;

namespace FoodSiteMAUI.Data.Services.Concrete
{
    public class RecipeMaterialService : IRecipeMaterialService
    {
        private readonly HttpClient _httpClient;
        public RecipeMaterialService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
        public async void Delete(int id)
        {
           var responseMessage= await _httpClient.DeleteAsync($"api/RecipeMaterials/{id}");
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
