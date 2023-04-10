using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string Materials { get; set; }
        public string RecipeContent { get; set; }
        public string Image { get; set; }
        public int NumberofPerson { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime RecipeDateTime { get; set; }
        public bool IsConfirm { get ; set; }= false;
        public bool IsSend { get; set; }= false;
        public int CategoryId { get; set; }
    }
}
