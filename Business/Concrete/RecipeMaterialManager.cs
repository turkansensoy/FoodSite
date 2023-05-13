using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RecipeMaterialManager : IRecipeMaterialService
    {
        private readonly IRecipeMaterialRepository _recipeMaterialRepository;
        public RecipeMaterialManager(IRecipeMaterialRepository recipeMaterialRepository)
        {
            _recipeMaterialRepository = recipeMaterialRepository;
        }
        public string Add(RecipeMaterial recipeMaterial)
        {
            _recipeMaterialRepository.Add(recipeMaterial);
            return "";
        }

        public string Delete(RecipeMaterial recipeMaterial)
        {
            _recipeMaterialRepository.Delete(recipeMaterial);
            return "";
        }

        public List<RecipeMaterial> GetAll()
        {
            return _recipeMaterialRepository.GetAll();
        }

        public RecipeMaterial GetById(int id)
        {
            return _recipeMaterialRepository.Get(_ => _.Id == id);
        }

        public string Update(RecipeMaterial recipeMaterial)
        {
            _recipeMaterialRepository.Update(recipeMaterial);
            return "";
        }
        public MultiSelectMaterialDto GetByMultiSelectMaterialDto(int id)
        {
            return _recipeMaterialRepository.GetAllRecipeMaterial(id);
        }
    }
}
