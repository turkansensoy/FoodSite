﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class RecipeMenu
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int MenuId { get; set; }
    }
}
