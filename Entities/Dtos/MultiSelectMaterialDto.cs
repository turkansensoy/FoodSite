using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class MultiSelectMaterialDto
    {
        public int id { get; set; }
        public int MaterialId { get; set; }
        public int MaterialNumber { get; set; }
        public string MaterialName { get; set; }
        public Guantity Guantity { get; set; }
    }
}
