using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreAppUsingMVC.Models
{
    public class Test
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [Editable(false, AllowInitialValue = true)]
        [Display(Name = "Unique ID")]
        public long UniqueId { get; set; } = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }
}
