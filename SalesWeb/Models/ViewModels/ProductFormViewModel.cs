using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Models.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
