using StoreManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.ViewModel
{
    public class ProductDetailViewModel
    {
        public Product Product { get; set; }
        public ProductExtraInfo ProductExtraInfo { get; set; }
    }
}
