﻿using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMaterialRepository :IRepository<Material>
    {
        List<MaterialDto> GetMaterials();
        List<MultiSelectMaterialDto> GetAllRecipeMaterial(int id);
    }
}
