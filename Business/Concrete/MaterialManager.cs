using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MaterialManager : IMaterialService
    {
       private readonly IMaterialRepository _materialRepository;
        public MaterialManager(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }
        public List<MaterialDto> GetAll()
        {
           return  _materialRepository.GetMaterials();
        }

        public List<MultiSelectMaterialDto> GetByMultiSelectMaterialDto(int id)
        {
           return _materialRepository.GetAllRecipeMaterial(id);
        }

        public Material GetByName(string name)
        {
            return _materialRepository.Get(_ => _.MaterialName == name);
        }
    }
}
