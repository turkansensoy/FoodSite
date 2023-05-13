using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RecipeEngineDto
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public bool IsConfirm { get; set; }
        public List<MaterialDto> MaterialDtos { get; set; }
    }
}
