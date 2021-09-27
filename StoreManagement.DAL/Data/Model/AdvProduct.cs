using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

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

        [Display(Name = "Cost Price")]
        public decimal Cost_Price { get; set; }

        [Required]
        [Display(Name = "HSN Code")]
        public string HSN_Code { get; set; }

        [Display(Name = "Is Financeable")]
        public bool Is_Financeable { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Updated On")]
        public DateTime? UpdatedOn { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("AdvProduct")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
