using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSiteMAUI.Data.Services.Abstract
{
    public interface IMaterialService
    {
        Task<List<MaterialDto>> GetAll();
        Task<Material> GetByMaterialName(string materialName);
        Task<List<MultiSelectMaterialDto>> GetMultiSelectMaterial(int id);
    }
}
