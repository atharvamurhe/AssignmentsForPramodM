using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Data.Model
{
    public class ProductExtraInfo
    {
        public int Id { get; set; }
        public decimal Product_Cost_Price { get; set; }
        public string HSN_Code { get; set; }
        public bool IsFinanceable { get; set; }
    }
}
