using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class RecipeMaterialRepository :EFRepositoryBase<RecipeMaterial, BaseDbContext>, IRecipeMaterialRepository
    {
        public MultiSelectMaterialDto GetAllRecipeMaterial(int id)
        {
            using (BaseDbContext context = new())
            {
                var result = (from rmaterial in context.RecipeMaterials
                              join material in context.Materials on rmaterial.MaterialId equals material.Id
                              where (rmaterial.Id == id)
                              select new MultiSelectMaterialDto
                              {
                                  id = rmaterial.Id,
                                  MaterialId = rmaterial.MaterialId,
                                  MaterialNumber = rmaterial.MaterialNumber,
                                  Guantity = rmaterial.Guantity
                              }).SingleOrDefault();
                return (MultiSelectMaterialDto)result;
            }
        }
    }
}
