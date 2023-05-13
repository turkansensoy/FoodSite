using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class MaterialRepository : EFRepositoryBase<Material, BaseDbContext>, IMaterialRepository
    {
        public List<MultiSelectMaterialDto> GetAllRecipeMaterial(int id)
        {
            using (BaseDbContext context = new())
            {
                var result = (from rmaterial in context.RecipeMaterials
                              join material in context.Materials on rmaterial.MaterialId equals material.Id
                              where (rmaterial.RecipeId == id)
                              select new MultiSelectMaterialDto
                              {
                                  id = rmaterial.Id,
                                  MaterialId = material.Id,
                                  MaterialName = material.MaterialName,
                                  MaterialNumber = rmaterial.MaterialNumber,
                                  Guantity = rmaterial.Guantity
                              }).ToList();
                return result;
            }
        }

        public List<MaterialDto> GetMaterials()
        {
            using (BaseDbContext context = new())
            {
                var result = from m in context.Materials
                             select new MaterialDto
                             {
                                 Id = m.Id,
                                 MaterialName = m.MaterialName
                             };
                return result.ToList();
            }
        }
    }
}
