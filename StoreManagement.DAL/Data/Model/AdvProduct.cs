using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreManagement.DAL.Data.Model
{
    public class AdvProduct
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Select Category")]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost_Price { get; set; }
        [Required]
        public string HSN_Code { get; set; }
        public bool Is_Financeable { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("AdvProduct")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
