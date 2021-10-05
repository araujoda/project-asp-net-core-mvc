using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int id, string name, double price, int quantity, Department department)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Department = department;
        }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public int Quantity { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "{0} Required")]
        public int DepartmentId { get; set; }

    }
}
