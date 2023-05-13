using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Material
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public Material()
        {
            RecipeMaterials = new HashSet<RecipeMaterial>();
        }
        public ICollection<RecipeMaterial> RecipeMaterials { get; set;}
    }
}
