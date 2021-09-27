using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstCoreAppUsingMVC.Models
{
    public class EnumTest
    {
        public int Id { get; set; }
        public string Namw { get; set; }
        public Gender GetGender { get; set; }
    }

    public enum Gender
    {
        [Display(Name = "Male")] Male = 1,
        [Display(Name = "Female N")] Female = 2,
        [Display(Name = "Other")] Other = 3
    }
}
