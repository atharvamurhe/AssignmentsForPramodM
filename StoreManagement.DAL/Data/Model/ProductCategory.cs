using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreManagement.DAL.Data.Model
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            AdvProduct = new HashSet<AdvProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [InverseProperty("ProductCategory")]
        public virtual ICollection<AdvProduct> AdvProduct { get; set; }
    }
}
