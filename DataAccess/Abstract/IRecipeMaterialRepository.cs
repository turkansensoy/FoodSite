using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRecipeMaterialRepository: IRepository<RecipeMaterial>
    {
        MultiSelectMaterialDto GetAllRecipeMaterial(int id);
    }
}
