using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CategorySoldModel
    {
        public List<CategorySoldColsModel> cols { get; set; }
        public List<CategorySoldRowsModel> rows { get; set; }
    }
}
