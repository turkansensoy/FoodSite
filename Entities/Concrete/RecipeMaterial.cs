using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RecipeMaterial
    {
        public int Id { get; set; }
        public int MaterialNumber { get; set; }
        public Guantity Guantity { get; set; }
        public int RecipeId { get; set; }
        public int MaterialId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Material Material { get; set; }

    }
}
