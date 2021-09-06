using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.DAL.Data.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required] //Specifies that this feild is required.
        [StringLength(100)] //Specifies the character limit for the this feild.
        public string Product_Name { get; set; }

        [Required]
        [Display(Name = "Category")] //Specifies the display name for this label.
        public string Product_Category { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Product_Price { get; set; }
    }
}
