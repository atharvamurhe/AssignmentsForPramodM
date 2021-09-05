using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.DAL.Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Category { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Product_Price { get; set; }
    }
}
