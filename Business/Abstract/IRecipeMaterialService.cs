using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRecipeMaterialService
    {
        List<RecipeMaterial> GetAll();
        String Add(RecipeMaterial recipeMaterial);
        String Update(RecipeMaterial recipeMaterial);
        String Delete(RecipeMaterial recipeMaterial);
        RecipeMaterial GetById(int id);
        MultiSelectMaterialDto GetByMultiSelectMaterialDto(int id);
    }
}
