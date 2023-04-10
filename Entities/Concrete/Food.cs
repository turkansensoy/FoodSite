using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Food
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string Materials { get; set; }
        public string Recipe { get; set;}
        public string Image { get; set; }
        public string NumberofPerson { get; set; }
        public int PreparationTime { get; set; }
        public int Score { get; set; }
        public string SenderPerson { get; set; }
        public DateTime FoodDateTime { get; set; }
        public int CategoryId { get; set; }
    }
}
