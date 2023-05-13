using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RecipeMaterialDto
    {
        public int Id { get; set; }
        public int MaterialNumber { get; set; }
        public Guantity Guantity { get; set; }
        public int MaterialId { get; set; }
    }
}
