using StoreManagement.DAL.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagement.Services.ViewModel
{
    public class vwJoinData
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
    }

    public class vwProductCategory
    {
        public string Category { get; set; }
    }
}
